using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using Model.DTO;

namespace UI
{
    public partial class OrderingMain : Form
    {
        private readonly RoomInfoBLL _roomInfoBLL = new RoomInfoBLL();
        private readonly DeskInfoBLL _deskInfoBLL = new DeskInfoBLL();
        private readonly OrderInfoBLL _orderInfoBLL = new OrderInfoBLL();
        private readonly OrderDeskAdd _orderDeskAdd = new OrderDeskAdd();
        

        //开单事件，传递桌面信息
        private event EventHandler AddOrderDeskEvent;
        //添加订单消费事件，传递桌面以及订单信息
        private event EventHandler AddOrderProductEvent;

        public OrderingMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadRoomsInfo();
            LoadDeskInfoByRoomId();
            //绑定开单传递桌面信息事件
            AddOrderDeskEvent += _orderDeskAdd.GetOrderDeskInfo;
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
                tabPage.Tag = room;
            }
        }

        //根据房间类型加载桌面信息
        private void LoadDeskInfoByRoomId()
        {
            var selectedTab = tabControl.SelectedTab;
            // 清除 TabPage 中的旧控件
            selectedTab.Controls.Clear();
            //创建ListView用于展示桌面信息
            var listView = new ListView();
            selectedTab.Controls.Add(listView);
            listView.Dock = DockStyle.Fill;
            listView.View = View.LargeIcon;
            listView.LargeImageList = imageList1;
            listView.MultiSelect = false;
            //获取当前选中的房间类型Tab页
            var selectedTabTag = selectedTab.Tag as DataRow;
            var roomId = Convert.ToInt32(selectedTabTag?["RoomId"]);
            //根据roomId查询所属类型的桌面
            var dataTable = _deskInfoBLL.GetDeskInfoByRoomId(roomId);
            //填充数据到ListView中
            foreach (DataRow row in dataTable.Rows)
            {
                var listViewItem = new ListViewItem(row["DeskName"].ToString())
                {
                    ImageIndex = Convert.ToInt32(row["DeskState"]),
                    Tag = row
                };
                listView.Items.Add(listViewItem);
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

        //进入会员管理界面事件
        private void btnMember_Click(object sender, EventArgs e)
        {
            var memberManager = new MemberManager();
            memberManager.Show();
        }

        //进入商品管理界面事件
        private void btnCategory_Click(object sender, EventArgs e)
        {
            var productManager = new ProductManager();
            productManager.Show();
        }

        //切换房间类型事件
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDeskInfoByRoomId();
        }

        //顾客开单事件
        private void btnBiling_Click(object sender, EventArgs e)
        {
            //获取待开单的桌面信息
            var listView = tabControl.SelectedTab.Controls[0] as ListView;
            if (listView?.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"请选择待开单的桌面");
                return;
            }

            var deskDataRow = listView?.SelectedItems[0].Tag as DataRow;
            var roomDataRow = tabControl.SelectedTab.Tag as DataRow;
            if (deskDataRow == null || roomDataRow == null)
            {
                MessageBox.Show(@"请选择待开单的桌面");
                return;
            }

            // 构造AddOrderDeskDTO对象
            var addOrderDeskDTO = new AddOrderDeskDTO
            {
                DeskName = deskDataRow["DeskName"].ToString(),
                RoomId = Convert.ToInt32(deskDataRow["RoomId"]),
                RoomName = roomDataRow["RoomName"].ToString(),
                RoomMinConsumption = Convert.ToInt32(roomDataRow["RoomMinConsumption"]),
                DeskId = Convert.ToInt32(deskDataRow["DeskId"])
            };
            //判断桌面信息是否可以空闲
            if (Convert.ToInt32(deskDataRow["DeskState"]) == 1)
            {
                MessageBox.Show(@"此桌面被使用中，无法开单");
                return;
            }

            AddOrderDeskEvent?.Invoke(this, addOrderDeskDTO);
            _orderDeskAdd.ShowDialog();
            //开单后刷新桌面界面
            LoadDeskInfoByRoomId();
        }

        // 追加订单消费商品事件
        private void btnMoney_Click(object sender, EventArgs e)
        {
            var tabPage = tabControl.SelectedTab;
            var roomDataRow = tabPage.Tag as DataRow;
            var listView = tabControl.SelectedTab.Controls[0] as ListView;
            if (listView == null || listView.SelectedItems.Count <= 0)
            {
                MessageBox.Show(@"请选择桌面后再操作");
                return;
            }
            var deskRow = listView.SelectedItems[0].Tag as DataRow;
            if (deskRow == null || Convert.ToInt32(deskRow["DeskState"]) == 0)
            {
                MessageBox.Show(@"请选择已开单的桌面");
                return;
            }
            //获取选中餐桌的最新订单号
            var deskId = Convert.ToInt32(deskRow["DeskId"]);
            var orderId = _orderInfoBLL.GetOrderIdByDeskId(deskId);
            var addOrderDeskDTO = new AddOrderDeskDTO()
            {
                DeskId = deskId,
                OrderId = orderId,
                RoomName = roomDataRow?["RoomName"].ToString(),
                DeskName = deskRow["DeskName"].ToString()
            };
            //创建订单添加商品页面，调用事件
            var orderAddProduct = new OrderAddProduct();
            AddOrderProductEvent += orderAddProduct.GetOrderAddProductInfo;
            AddOrderProductEvent?.Invoke(this, addOrderDeskDTO);
            orderAddProduct.ShowDialog();
        }
    }
}