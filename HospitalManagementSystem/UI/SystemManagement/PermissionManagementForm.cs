using System;
using System.Windows.Forms;

namespace HospitalManagementSystem.SystemManagement
{
    public partial class PermissionManagementForm : Form
    {
        public PermissionManagementForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {
            
        }

        //打开新增权限窗口事件
        private void button2_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(@"此操作非常危险！请确定你需要新增权限！执行操作后必须迭代版本，不然会使程序异常！"
                , @"警告",MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {
                new PermissionAddOrUpdate().ShowDialog();
            }
        }
        //打开新增模块窗口事件
        private void button7_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(@"此操作非常危险！请确定你需要新增权限！执行操作后必须迭代版本，不然会使程序异常！"
                , @"警告",MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {
                new ModuleAddOrUpdate().ShowDialog();
            }
        }
    }
}