using System;
using System.Windows.Forms;
using BLL;
using Model;

namespace HospitalManagementSystem.SystemManagement
{
    public partial class ModuleAddOrUpdate : Form
    {
        
        private readonly ModuleBLL _moduleBLL = new ModuleBLL();
        private bool _isUpdate;
        
        public ModuleAddOrUpdate()
        {
            InitializeComponent();
        }

        // 加载数据，并根据数据的有无判断是修改操作还是新增操作
        public void LoadData(Module module)
        {
            if (module == null ) return;
            _isUpdate = true;
            textBox1.Text = module.ModuleId.ToString();
            textBox2.Text = module.Name;
            textBox3.Text = module.Description;
        }

        //根据新增或修改的情况，设置控件的样式
        private void ChangeStyle()
        {
            //不允许选中textbox1
            textBox1.Enabled = false;
            this.Text = _isUpdate ? "修改模块" : "添加模块";
            button1.Text = _isUpdate ? "修改" : "添加";
        }
        
        private void ModelAddOrUpdate_Load(object sender, EventArgs e)
        {
            ChangeStyle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var module = new Module
            {
                Name = textBox2.Text,
                Description = textBox3.Text
            };
            var result = _moduleBLL.AddModule(module);
           MessageBox.Show(result.Message);
           this.Close();
        }
    }
}