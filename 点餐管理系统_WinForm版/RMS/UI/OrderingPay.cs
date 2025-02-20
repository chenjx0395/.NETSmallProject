using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BLL;
using Model;
using Model.DTO;

namespace UI
{
    public partial class OrderingPay : Form
    {
        
        private readonly OrderInfoBLL _orderInfoBLL = new OrderInfoBLL();
        private readonly MemberInfoBLL _memberInfoBLL = new MemberInfoBLL();
        private readonly DeskInfoBLL _deskInfoBLL = new DeskInfoBLL();
        private MemberInfo _memberInfo;
        private AddOrderDeskDTO _orderDeskDTO;
        public OrderingPay()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            checkBox1.Checked = true;
        }

        
        //结账事件
        private void button1_Click(object sender, EventArgs e)
        {
            // 待支付的金额
            var amountToBePaid = Convert.ToDouble(label14.Text);
            //判断是否是会员结账
            if (_memberInfo != null)
            {
                //判断会员的余额是否足够
                if (_memberInfo.Money >= amountToBePaid)
                {
                    //修改余额，添加积分，修改订单状态
                    _memberInfo.Money -= amountToBePaid;
                    _memberInfo.Points = (int) amountToBePaid;
                    _memberInfoBLL.UpdateMemberInfoMoneyAndPoints(_memberInfo);
                    var orderInfo = new OrderInfo
                    {
                        OrderId = _orderDeskDTO.OrderId,
                        EndTime = DateTime.Now,
                        DisCount = _memberInfo.Discount,
                        OrderMoney = amountToBePaid
                    };
                    _orderInfoBLL.UpdateOrderState(orderInfo);
                }
                else
                {
                    MessageBox.Show(@"会员余额不足，请先充值");
                    return;
                }
            }
            else
            {
                MessageBox.Show($@"请支付{amountToBePaid}元");
                //修改订单状态
                var orderInfo = new OrderInfo
                {
                    OrderId = _orderDeskDTO.OrderId,
                    EndTime = DateTime.Now,
                    DisCount = 0,
                    OrderMoney = amountToBePaid
                };
                _orderInfoBLL.UpdateOrderState(orderInfo);
            }
            //修改桌面状态
            _deskInfoBLL.UpdateDeskStateToFreeById(_orderDeskDTO.DeskId);
            MessageBox.Show(@"结账成功！");
            this.Close();
        }

        //获取订单相关信息事件
        public void GetOrderProductInfo(object sender, EventArgs e)
        {
            var addOrderDeskDTO = e as AddOrderDeskDTO;
            if (addOrderDeskDTO == null)
            {
                MessageBox.Show(@"错误");
                return;
            }
            _orderDeskDTO = addOrderDeskDTO;
            label2.Text = addOrderDeskDTO.OrderId.ToString();
            label3.Text = addOrderDeskDTO.DeskName;
            // 查询该订单下的商品信息
            dgvROrderProduct.DataSource = _orderInfoBLL.GetOrderProductByOrderId(addOrderDeskDTO.OrderId);
            var sum = dgvROrderProduct.Rows.Cast<DataGridViewRow>().Sum(row => Convert.ToInt32(row.Cells[5].Value));
            label13.Text = sum.ToString();
            label5.Text = sum.ToString();
            label14.Text = sum.ToString();
        }

        //显示会员相关事件
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            label7.Visible = !label7.Visible;
            textBox1.Visible = !textBox1.Visible;
            label17.Visible = !label17.Visible;
            label16.Visible = !label16.Visible;
            label8.Visible = !label8.Visible;
            label10.Visible = !label10.Visible;
            label9.Visible = !label9.Visible;
            label11.Visible = !label11.Visible;
            label14.Text = label13.Text;
        }

        //查询会员信息事件
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 4)
            {
                var memberInfo = _memberInfoBLL.GetMemberInfoByPhoneNum(textBox1.Text);
                if (memberInfo == null) return;
                _memberInfo = memberInfo;
                label16.Text = memberInfo.Mname;
                label8.Text = memberInfo.Money.ToString(CultureInfo.InvariantCulture);
                label10.Text = memberInfo.Discount.ToString(CultureInfo.InvariantCulture);
                label14.Text =
                    (Convert.ToInt32(label14.Text) * memberInfo.Discount * 0.1).ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                label10.Text = "";
                label16.Text = "";
                label8.Text = "";
                label14.Text = label13.Text;
                _memberInfo = null;
            }
        }
    }
}