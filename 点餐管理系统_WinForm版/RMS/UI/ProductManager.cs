using System;
using System.Windows.Forms;
using BLL;
using Model;

namespace UI
{
    public partial class ProductManager : Form
    {
        //定义修改商品类别传递商品信息的事件
        public event EventHandler UpdateToCategoryEvent;
        private readonly CategoryInfoBLL _categoryInfoBLL = new CategoryInfoBLL();
        private readonly ProductInfoBLL _productInfoBLL = new ProductInfoBLL();
        public ProductManager()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadCategoryInfo();
            LoadProductInfo();
        }

        private void LoadCategoryInfo()
        {
            dgvCategoryInfo.DataSource = _categoryInfoBLL.GetCategoryInfoList();
        }

        private void LoadProductInfo()
        {
            dgvProductInfo.DataSource = _productInfoBLL.GetProductInfoList();
        }

        // 双击显示选中类别的商品
        private void dgvCategoryInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //获取选中行的类别ID
            var categoryId = Convert.ToInt32(dgvCategoryInfo.SelectedRows[0].Cells[0].Value);
            dgvProductInfo.DataSource = _productInfoBLL.GetProductInfoListByCategory(categoryId);
        }
        
        //显示所有类别的商品
        private void btnShowAllProductInfo_Click(object sender, EventArgs e)
        {
            LoadProductInfo();
        }
        //新增商品类别
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            var categoryInsertForms = new CategoryInfoInsertOrUpdate();
            var dialogResult = categoryInsertForms.ShowDialog();
            switch (dialogResult)     
            {
                case DialogResult.OK:
                    MessageBox.Show(@"新增商品类别成功");
                    break;
                case DialogResult.No:
                    MessageBox.Show(@"新增商品类别失败");
                    break;
            }
            LoadCategoryInfo();
        }
       
        //修改商品类别信息
        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            
            // 获取当前选中的类别信息
            var dataGridViewRow = dgvCategoryInfo.SelectedRows[0];
            if (dataGridViewRow == null)
            {
                MessageBox.Show(@"请先选择商品类别");
                return;
            }
            //构造类别信息对象
            var categoryInfo = new CategoryInfo
            {
                CatId = Convert.ToInt32(dataGridViewRow.Cells[0].Value),
                CatName = dataGridViewRow.Cells[1].Value.ToString(),
                Remark = dataGridViewRow.Cells[2].Value.ToString(),
                SubTime = Convert.ToDateTime(dataGridViewRow.Cells[3].Value)
            };
            var updateForms = new CategoryInfoInsertOrUpdate();
            UpdateToCategoryEvent += updateForms.GetUpdateCategoryInfo;
            UpdateToCategoryEvent?.Invoke(this,categoryInfo);
            var dialogResult = updateForms.ShowDialog();
            switch (dialogResult)     
            {
                case DialogResult.OK:
                    MessageBox.Show(@"修改商品类别成功");
                    break;
                case DialogResult.No:
                    MessageBox.Show(@"修改商品类别失败");
                    break;
            }
            LoadCategoryInfo();
        }
        //删除商品类别信息
        private void benDeleteCategory_Click(object sender, EventArgs e)
        {
            // 获取当前选中的类别信息
            var dataGridViewRow = dgvCategoryInfo.SelectedRows[0];
            if (dataGridViewRow == null)
            {
                MessageBox.Show(@"请先选择商品类别");
                return;
            }
            var id = Convert.ToInt32(dataGridViewRow.Cells[0].Value);
            MessageBox.Show(_categoryInfoBLL.DeleteCategoryById(id) > 0 ? @"删除商品类别成功" : @"删除商品类别失败");
            LoadCategoryInfo();
        }
    }
}