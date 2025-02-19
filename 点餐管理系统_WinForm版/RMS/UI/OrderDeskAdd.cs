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
        private AddOrderDeskDTO _addOrderDeskDTO;

        private event EventHandler AddOrderProductEvent;
        
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
            _addOrderDeskDTO.OrderId = insertId;
            //修改桌面状态
            var updateRow = _deskInfoBLL.UpdateDeskStateToUseById(_addOrderDeskDTO.DeskId);
            //新增订单桌面关系表
            var insertRow = _orderInfoBLL.InsertOrderDesk(insertId, _addOrderDeskDTO.DeskId);
            if (updateRow+insertRow >1)
            {
                this.DialogResult = DialogResult.OK;
                MessageBox.Show(@"开单成功");
                // 开单成功后如果勾选了直接添加消费，则打开给订单添加商品的页面
                if (ckbMeal.Checked)
                {
                    var orderAddProduct = new OrderAddProduct();
                    AddOrderProductEvent += orderAddProduct.GetOrderAddProductInfo;
                    AddOrderProductEvent?.Invoke(this,_addOrderDeskDTO);
                    orderAddProduct.ShowDialog();
                }
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
            _addOrderDeskDTO = e as AddOrderDeskDTO;
            if (_addOrderDeskDTO == null)
            {
                MessageBox.Show(@"添加异常");
                return;
            }
            label6.Text = _addOrderDeskDTO.RoomName;
            label7.Text = _addOrderDeskDTO.DeskName;
            label10.Text = _addOrderDeskDTO.RoomMinConsumption.ToString();
        }
    }
}