using System;
using System.Globalization;
using System.Windows.Forms;
using BLL;
using Model;

namespace UI
{
    public partial class CategoryInfoInsertOrUpdate : Form
    {
        private bool _isUpdate;
        private readonly CategoryInfoBLL _categoryInfoBLL = new CategoryInfoBLL();
        public CategoryInfoInsertOrUpdate()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            ChangeFormsViewByCategory();
        }

        //提交新增或修改
        private void button1_Click(object sender, EventArgs e)
        {
            //构造待操作的类别对象
            var categoryInfo = new CategoryInfo()
            {
                CatName = txtCname.Text,
                Remark = txtDesc.Text,
                DelFlag = 0,
                SubTime = registDate.Value
            };
            if (!string.IsNullOrWhiteSpace(txtCid.Text))
            {
                categoryInfo.CatId = Convert.ToInt32(txtCid.Text);
            }
            bool result;
            if (_isUpdate)
            {
                var rows = _categoryInfoBLL.UpdateCategoryById(categoryInfo);
                result = rows > 0;
            }
            else
            {
                var rows = _categoryInfoBLL.InsertCategoryInfo(categoryInfo);
                result = rows > 0;
            }

            this.DialogResult = result ? DialogResult.OK : DialogResult.No;
        }
        //获取商品管理页面修改类别操作触发后的类别信息
        public void GetUpdateCategoryInfo(object sender, EventArgs e)
        {
            _isUpdate = true;
            ChangeFormsViewByCategory();
            var categoryInfo = e as CategoryInfo;
            if (categoryInfo == null)
            {
                MessageBox.Show(@"获取类别信息失败");
                this.DialogResult = DialogResult.No;
                return;
            }
            //数据回显
            txtCid.Text = categoryInfo.CatId.ToString();
            txtCname.Text = categoryInfo.CatName;
            txtDesc.Text = categoryInfo.Remark;
            registDate.Text = categoryInfo.SubTime.ToString(CultureInfo.CurrentCulture);
        }

        //改变窗口视图的显示信息,根据新增还是修改操作
        private void ChangeFormsViewByCategory()
        {
            //修改操作的视图
            if (_isUpdate)
            {
                this.Text = @"修改类别信息";
                this.button1.Text = @"修改";
            }
            else
            {
                this.Text = @"新增类别信息";
                this.button1.Text = @"新增";
            }
                
        }
        
    }
}