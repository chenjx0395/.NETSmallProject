using System;
using System.Drawing;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class UserLogin : Form
    {
        private readonly UserBLL _userBLL = new UserBLL();
        public UserLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 登录按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginBtn_Click(object sender, EventArgs e)
        {
            //获取用户输入的用户名和密码
            var username = unameTextBox.Text.Trim();
            var password = pwdTextBox.Text.Trim();
            var loginResult = _userBLL.Login(username, password);
            switch (loginResult)
            {
                case 0:
                    LoginPrompLabel.ForeColor = Color.Red;
                    LoginPrompLabel.Text = "账号密码错误";
                    break;
                case 1:
                    LoginPrompLabel.ForeColor = Color.Red;
                    LoginPrompLabel.Text = "请使用经理账号登录";
                    break;
                case 2:
                    /*LoginPrompLabel.ForeColor = Color.Green;
                    LoginPrompLabel.Text = "登录成功";*/
                    // 登录成功，跳转到用户管理界面
                    UserManager userManager = new UserManager();
                    userManager.StartPosition = FormStartPosition.CenterScreen;
                    userManager.Show();
                    this.Hide();
                    break;
            }
        }

       
    }
}
