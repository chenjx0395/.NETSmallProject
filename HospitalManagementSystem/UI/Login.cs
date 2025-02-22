using System;
using System.Windows.Forms;


namespace HospitalManagementSystem
{
    public partial class Login : Form
    {

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
            
        }
    }
}