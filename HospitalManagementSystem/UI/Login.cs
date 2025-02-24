using System;
using System.Windows.Forms;
using BLL;
using Common.Attribute;
using Common.Enum.Permissions;


namespace HospitalManagementSystem
{
    public partial class Login : Form
    {

        private readonly UserBLL _userBLL = new UserBLL();

        public Login()
        {
            this.InitializeComponent();
            // 无边框
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        //退出事件
        private void button2_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //登录事件
        private void button1_Click(object sender, EventArgs e)
        {
            // 验证用户名密码
            var result = _userBLL.GetUser(txtUname.Text, txtPwd.Text);
            if (result.Code == 2000)
            {
                var mainPage = new MainPage();
                mainPage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }
    }
}