using System;
using System.Windows.Forms;
using BLL;
using Model;
using Model.DTO;

namespace UI
{
    public partial class OrderDeskAdd : Form
    {
        private readonly OrderInfoBLL _orderInfoBLL = new OrderInfoBLL();
        private readonly DeskInfoBLL _deskInfoBLL = new DeskInfoBLL();
        private int _deskId;
        
        public OrderDeskAdd()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        //开单事件
        private void btnOK_Click(object sender, EventArgs e)
        {
            //构造订单对象
            var orderInfo = new OrderInfo
            {
                SubTime = DateTime.Now,
                Remark = txtDescription.Text,
                NumberOfDiners = Convert.ToInt32(txtPersonCount.Text),
            };
            //执行新增语句，获取新建的订单编号
            var insertId = _orderInfoBLL.InsertOrderAndGetId(orderInfo);
            //修改桌面状态
            var updateRow = _deskInfoBLL.UpdateDeskStateToUseById(_deskId);
            //新增订单桌面关系表
            var insertRow = _orderInfoBLL.InsertOrderDesk(insertId, _deskId);
            if (updateRow+insertRow >1)
            {
                this.DialogResult = DialogResult.OK;
                MessageBox.Show(@"开单成功");
            }
            else
            {
                this.DialogResult = DialogResult.No;
                MessageBox.Show(@"开单失败");
            }
            txtDescription.Text = "";
            txtPersonCount.Text = "";
            this.Close();
        }
        //获取开单的桌面信息
        public void GetOrderDeskInfo(object sender, EventArgs e)
        {
            var addOrderDeskDTO = e as AddOrderDeskDTO;
            if (addOrderDeskDTO == null)
            {
                MessageBox.Show(@"添加异常");
                return;
            }
            label6.Text = addOrderDeskDTO.RoomName;
            label7.Text = addOrderDeskDTO.DeskName;
            label10.Text = addOrderDeskDTO.RoomMinConsumption.ToString();
            _deskId = addOrderDeskDTO.DeskId;
        }
    }
}