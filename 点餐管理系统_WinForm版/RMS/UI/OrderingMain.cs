using System;
using System.Windows.Forms;

namespace UI
{
    public partial class OrderingMain : Form
    {
        public OrderingMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void OrderingMain_Load(object sender, EventArgs e)
        {
            ShowDateTimeNow();
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void ShowDateTimeNow()
        {
            labTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        private void OrderingMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ShowDateTimeNow();
        }

        /// <summary>
        /// 进入会员管理界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMember_Click(object sender, EventArgs e)
        {
            var memberManager = new MemberManager();
            memberManager.Show();
        }
    }
}
