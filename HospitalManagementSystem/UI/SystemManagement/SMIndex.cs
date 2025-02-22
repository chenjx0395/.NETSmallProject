using System;
using System.Windows.Forms;

namespace HospitalManagementSystem.SystemManagement
{
    public partial class SMIndex : Form
    {
        public SMIndex()
        {
            InitializeComponent();
        }

        //打开权限管理界面事件
        private void label1_Click(object sender, EventArgs e)
        {
            var permissionManagementForm = new PermissionManagementForm();
           permissionManagementForm.ShowDialog();
        }
    }
}