using System;
using System.Windows.Forms;
using Model.DTO;

namespace UI
{
    public partial class OrderDeskAdd : Form
    {
        public OrderDeskAdd()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        //开单订购桌面事件
        private void btnOK_Click(object sender, EventArgs e)
        {
            
        }
        //获取开单的桌面信息
        public void GetOrderDeskInfo(object sender, EventArgs e)
        {
            var addOrderDeskDTO = e as AddOrderDeskDTO;
            label6.Text = addOrderDeskDTO?.RoomName;
            label7.Text = addOrderDeskDTO?.DeskName;
            label10.Text = addOrderDeskDTO?.RoomMinConsumption.ToString();
        }
    }
}