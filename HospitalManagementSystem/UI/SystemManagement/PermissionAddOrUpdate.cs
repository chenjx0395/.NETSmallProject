using System;
using System.Windows.Forms;
using BLL;
using DAL;
using Model;

namespace HospitalManagementSystem.SystemManagement
{
    public partial class PermissionAddOrUpdate : Form
    {

        private readonly PermissionBLL _permissionBLL = new PermissionBLL();
        private readonly ModuleBLL _moduleBLL = new ModuleBLL();
        private bool _isUpdate;
        
        public PermissionAddOrUpdate()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        // 加载数据，并根据数据的有无判断是修改操作还是新增操作
        public void LoadData(Permission permission)
        {
            if (permission == null ) return;
            _isUpdate = true;
            textBox1.Text = permission.PermissionId.ToString();
            textBox2.Text = permission.Name;
            textBox3.Text = permission.Description;
        }

        //根据新增或修改的情况，设置控件的样式
        private void ChangeStyle()
        {
            //不允许选中textbox1
            textBox1.Enabled = false;
            this.Text = _isUpdate ? "修改权限" : "添加权限";
            button1.Text = _isUpdate ? "修改" : "添加";
        }

        private void PermissionAddOrUpdate_Load(object sender, EventArgs e)
        {
            ChangeStyle();
            // 加载模型下列选择框数据
            var result = _moduleBLL.GetModuleList();
            if (result.Code != 2000)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                comboBox1.DataSource = result.Value;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "ModuleId";
            }
        }

        //提交事件
        private void button1_Click(object sender, EventArgs e)
        {
            var permission = new Permission
            {
                Name = textBox2.Text,
                Description = textBox3.Text
            };
            // 事务处理
            using (var tran  = SQLHelper.BeginTransaction())
            {
                try
                {
                    var res1 = _permissionBLL.AddPermission(tran,permission);
                    var mP = new ModulePermission
                    {
                        ModuleId = Convert.ToInt32(comboBox1.SelectedValue),
                        PermissionId = res1.Value
                    };
                    //给模块关系表新增数据
                    _permissionBLL.AddModulePermission(tran,mP);
                    tran.Commit();
                    MessageBox.Show(res1.Message);
                    // this.Close();
                }
                catch (Exception exception)
                {
                    tran.Rollback();
                    MessageBox.Show($@"系统异常：{exception.Message}");
                }
            }
            
        }
    }
}