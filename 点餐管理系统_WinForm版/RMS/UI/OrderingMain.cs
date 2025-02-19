using System;
using System.Data;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class OrderingMain : Form
    {
        private readonly RoomInfoBLL _roomInfoBLL = new RoomInfoBLL();
        
        public OrderingMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadRoomsInfo();
        }

        private void OrderingMain_Load(object sender, EventArgs e)
        {
            ShowDateTimeNow();
            timer1.Interval = 1000;
            timer1.Start();
        }

        //加载包房信息
        private void LoadRoomsInfo()
        {
            //查询所有的包房信息
            var roomInfoList = _roomInfoBLL.GetRoomInfoList();
            var roomsInfo = roomInfoList.Rows;
            foreach (DataRow room in roomsInfo)
            {
                // 创建Tab项
                var tabPage = new TabPage(room["RoomName"].ToString());
                tabControl.TabPages.Add(tabPage);
            }
            
        }
        
        //获取当前时间用于展示
        private void ShowDateTimeNow()
        {
            labTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        //关闭窗口后关闭程序
        private void OrderingMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //计时器:每秒刷新当前时间展示信息
        private void timer1_Tick(object sender, EventArgs e)
        {
            ShowDateTimeNow();
        }

        //进入会员管理界面
        private void btnMember_Click(object sender, EventArgs e)
        {
            var memberManager = new MemberManager();
            memberManager.Show();
        }

        //进入商品管理界面
        private void btnCategory_Click(object sender, EventArgs e)
        {
            var productManager = new ProductManager();
            productManager.Show();
        }
    }
}
