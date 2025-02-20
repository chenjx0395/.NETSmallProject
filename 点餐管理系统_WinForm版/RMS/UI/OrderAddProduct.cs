using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BLL;
using Model;
using Model.DTO;

namespace UI
{
    public partial class OrderAddProduct : Form
    {
        private int _orderId;
        private readonly OrderInfoBLL _orderInfoBLL = new OrderInfoBLL();
        private readonly ProductInfoBLL _productInfoBLL = new ProductInfoBLL();
        private readonly CategoryInfoBLL _categoryInfoBLL = new CategoryInfoBLL();
        // 已存在的商品编号
        private readonly HashSet<int> _existenceProductId = new HashSet<int>();

        public OrderAddProduct()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadProductList();
            LoadProductListByCategory();
        }

        // 获取待添加商品的订单信息事件
        public void GetOrderAddProductInfo(object sender, EventArgs e)
        {
            var addOrderDeskDTO = e as AddOrderDeskDTO;
            if (addOrderDeskDTO == null)
            {
                MessageBox.Show(@"添加异常");
                return;
            }

            label9.Text = addOrderDeskDTO.DeskName;
            label10.Text = addOrderDeskDTO.RoomName;
            _orderId = addOrderDeskDTO.OrderId;
            LoadOrderProductInfo();
        }

        //加载当前订单的商品信息
        private void LoadOrderProductInfo()
        {
            dgvROrderProduct.DataSource = _orderInfoBLL.GetOrderProductByOrderId(_orderId);
            var count = 0;
            var sum = 0;
            foreach (DataGridViewRow row in dgvROrderProduct.Rows)
            {   //将商品ID存储到唯一哈希集合中
                _existenceProductId.Add(Convert.ToInt32(row.Cells[0].Value));
                // 计算点单数量
                count += Convert.ToInt32(row.Cells[2].Value);
                // 计算合计金额
                sum += Convert.ToInt32(row.Cells[5].Value);
            }
            lblCount.Text = count.ToString();
            lblMoney.Text = sum.ToString();
        }
        //加载所有商品信息
        private void LoadProductList()
        {
            dgvProductInfo.DataSource = _productInfoBLL.GetProductInfoList();
        }
        //加载所有类别下的商品信息
        private void LoadProductListByCategory()
        {
            // 查询所有商品列表ID
            var dataRowCollection = _categoryInfoBLL.GetCategoryInfoList().Rows;
            foreach (DataRow rows in dataRowCollection)
            {
                var treeNode = new TreeNode(rows["CatName"].ToString());
                var productInfoListByCategory = _productInfoBLL.GetProductInfoListByCategory(Convert.ToInt32(rows["CatId"]));
                var rowCollection = productInfoListByCategory.Rows;
                foreach (DataRow dataRow in rowCollection)
                {
                    treeNode.Nodes.Add(dataRow["ProName"].ToString());
                }
                tvCategory.Nodes.Add(treeNode);
            }
           
        }

        //双击加入商品
        private void dgvProductInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           //获取选中的商品ID
            var productId = Convert.ToInt32(dgvProductInfo.SelectedRows[0].Cells[0].Value);
            var orderProduct = new OrderProduct
            {
                OrderId = _orderId,
                ProId = productId,
                SubTime = DateTime.Now,
                ProCount = 1
            };
            var row =
                // 存在执行update语句，修改商品数量
                _existenceProductId.Contains(productId) ? _orderInfoBLL.UpdateOrderProductCount(orderProduct) :
                // 不存在执行insert语句，添加商品
                _orderInfoBLL.InsertOrderProduct(orderProduct);
            if (row < 1)
            {
                MessageBox.Show(@"添加商品失败");
            }
            LoadOrderProductInfo();
        }
    }
}