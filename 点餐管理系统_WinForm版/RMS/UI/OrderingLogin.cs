using System;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using Common;

namespace UI
{
    public partial class OrderingLogin : Form
    {
        private string _verificationCode;
        private OrderingBLL _orderingBLL = new OrderingBLL();
        public OrderingLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void OrderLogin_Load(object sender, EventArgs e)
        {
            LoadVerificationCode();
        }
        /// <summary>
        /// 加载验证码
        /// </summary>
        private void LoadVerificationCode()
        {
            pictureBox1.Image = VerificationCodeUtil.GetCode();
            _verificationCode = VerificationCodeUtil.Code;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadVerificationCode();
        }

        /// <summary>
        /// 登录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //检查验证码是否输入正确
            if (textBox3.Text != _verificationCode)
            {
                MessageBox.Show("验证码错误，请重新输入");
                LoadVerificationCode();
                return;
            }

            var loginRes = _orderingBLL.Login(textBox1.Text, textBox2.Text);
            switch (loginRes)
            {
                case 0 :
                    label4.ForeColor = Color.Red;
                    label4.Text = "用户名或密码错误";
                    LoadVerificationCode();
                    break;
                case 1:
                    label4.ForeColor = Color.Green;
                    label4.Text = "登录成功";
                    break;
            }
        }

        //跳转到员工管理登录界面
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var userLogin = new UserLogin(this);
            this.Hide();
            userLogin.Show();
        }
    }
}
