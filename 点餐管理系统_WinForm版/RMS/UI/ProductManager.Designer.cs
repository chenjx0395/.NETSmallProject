using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    partial class ProductManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnUpdatePro = new System.Windows.Forms.Button();
            this.btnAddPro = new System.Windows.Forms.Button();
            this.btnUpdateCategory = new System.Windows.Forms.Button();
            this.dgvProductInfo = new System.Windows.Forms.DataGridView();
            this.ProId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProSpell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.benDeleteCategory = new System.Windows.Forms.Button();
            this.btnDeletePro = new System.Windows.Forms.Button();
            this.dgvCategoryInfo = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnShowAllProductInfo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoryInfo)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(720, 177);
            this.btnAddCategory.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(158, 46);
            this.btnAddCategory.TabIndex = 122;
            this.btnAddCategory.Text = "添加类别";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnUpdatePro
            // 
            this.btnUpdatePro.Location = new System.Drawing.Point(912, 295);
            this.btnUpdatePro.Margin = new System.Windows.Forms.Padding(6);
            this.btnUpdatePro.Name = "btnUpdatePro";
            this.btnUpdatePro.Size = new System.Drawing.Size(150, 46);
            this.btnUpdatePro.TabIndex = 127;
            this.btnUpdatePro.Text = "修改产品";
            this.btnUpdatePro.UseVisualStyleBackColor = true;
            // 
            // btnAddPro
            // 
            this.btnAddPro.Location = new System.Drawing.Point(720, 295);
            this.btnAddPro.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddPro.Name = "btnAddPro";
            this.btnAddPro.Size = new System.Drawing.Size(158, 46);
            this.btnAddPro.TabIndex = 128;
            this.btnAddPro.Text = "增加产品";
            this.btnAddPro.UseVisualStyleBackColor = true;
            // 
            // btnUpdateCategory
            // 
            this.btnUpdateCategory.Location = new System.Drawing.Point(912, 177);
            this.btnUpdateCategory.Margin = new System.Windows.Forms.Padding(6);
            this.btnUpdateCategory.Name = "btnUpdateCategory";
            this.btnUpdateCategory.Size = new System.Drawing.Size(150, 46);
            this.btnUpdateCategory.TabIndex = 121;
            this.btnUpdateCategory.Text = "修改类别";
            this.btnUpdateCategory.UseVisualStyleBackColor = true;
            this.btnUpdateCategory.Click += new System.EventHandler(this.btnUpdateCategory_Click);
            // 
            // dgvProductInfo
            // 
            this.dgvProductInfo.AllowUserToAddRows = false;
            this.dgvProductInfo.AllowUserToDeleteRows = false;
            this.dgvProductInfo.AllowUserToResizeColumns = false;
            this.dgvProductInfo.AllowUserToResizeRows = false;
            this.dgvProductInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductInfo.BackgroundColor = System.Drawing.Color.Tan;
            this.dgvProductInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.ProId, this.ProName, this.ProCost, this.ProSpell, this.ProPrice, this.ProUnit, this.Column6, this.SubTime, this.ProStock });
            this.dgvProductInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductInfo.Location = new System.Drawing.Point(6, 34);
            this.dgvProductInfo.Margin = new System.Windows.Forms.Padding(6);
            this.dgvProductInfo.Name = "dgvProductInfo";
            this.dgvProductInfo.ReadOnly = true;
            this.dgvProductInfo.RowHeadersVisible = false;
            this.dgvProductInfo.RowHeadersWidth = 20;
            this.dgvProductInfo.RowTemplate.Height = 23;
            this.dgvProductInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvProductInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductInfo.Size = new System.Drawing.Size(1592, 722);
            this.dgvProductInfo.TabIndex = 1;
            // 
            // ProId
            // 
            this.ProId.DataPropertyName = "ProId";
            this.ProId.HeaderText = "商品编号";
            this.ProId.MinimumWidth = 9;
            this.ProId.Name = "ProId";
            this.ProId.ReadOnly = true;
            // 
            // ProName
            // 
            this.ProName.DataPropertyName = "ProName";
            this.ProName.HeaderText = "商品名称";
            this.ProName.MinimumWidth = 9;
            this.ProName.Name = "ProName";
            this.ProName.ReadOnly = true;
            // 
            // ProCost
            // 
            this.ProCost.DataPropertyName = "ProCost";
            this.ProCost.HeaderText = "商品原价";
            this.ProCost.MinimumWidth = 9;
            this.ProCost.Name = "ProCost";
            this.ProCost.ReadOnly = true;
            // 
            // ProSpell
            // 
            this.ProSpell.DataPropertyName = "ProSpell";
            this.ProSpell.HeaderText = "商品拼音";
            this.ProSpell.MinimumWidth = 9;
            this.ProSpell.Name = "ProSpell";
            this.ProSpell.ReadOnly = true;
            // 
            // ProPrice
            // 
            this.ProPrice.DataPropertyName = "ProPrice";
            this.ProPrice.HeaderText = "商品单价";
            this.ProPrice.MinimumWidth = 9;
            this.ProPrice.Name = "ProPrice";
            this.ProPrice.ReadOnly = true;
            // 
            // ProUnit
            // 
            this.ProUnit.DataPropertyName = "ProUnit";
            this.ProUnit.HeaderText = "商品单位";
            this.ProUnit.MinimumWidth = 9;
            this.ProUnit.Name = "ProUnit";
            this.ProUnit.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Remark";
            this.Column6.HeaderText = "商品备注";
            this.Column6.MinimumWidth = 9;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // SubTime
            // 
            this.SubTime.DataPropertyName = "SubTime";
            this.SubTime.HeaderText = "创建日期";
            this.SubTime.MinimumWidth = 9;
            this.SubTime.Name = "SubTime";
            this.SubTime.ReadOnly = true;
            // 
            // ProStock
            // 
            this.ProStock.DataPropertyName = "ProStock";
            this.ProStock.HeaderText = "当前库存";
            this.ProStock.MinimumWidth = 9;
            this.ProStock.Name = "ProStock";
            this.ProStock.ReadOnly = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(1358, 303);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 35);
            this.txtSearch.TabIndex = 123;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1288, 311);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 124;
            this.label1.Text = "搜索";
            // 
            // benDeleteCategory
            // 
            this.benDeleteCategory.Location = new System.Drawing.Point(1098, 177);
            this.benDeleteCategory.Margin = new System.Windows.Forms.Padding(6);
            this.benDeleteCategory.Name = "benDeleteCategory";
            this.benDeleteCategory.Size = new System.Drawing.Size(150, 46);
            this.benDeleteCategory.TabIndex = 120;
            this.benDeleteCategory.Text = "删除类别";
            this.benDeleteCategory.UseVisualStyleBackColor = true;
            this.benDeleteCategory.Click += new System.EventHandler(this.benDeleteCategory_Click);
            // 
            // btnDeletePro
            // 
            this.btnDeletePro.Location = new System.Drawing.Point(1098, 297);
            this.btnDeletePro.Margin = new System.Windows.Forms.Padding(6);
            this.btnDeletePro.Name = "btnDeletePro";
            this.btnDeletePro.Size = new System.Drawing.Size(150, 46);
            this.btnDeletePro.TabIndex = 126;
            this.btnDeletePro.Text = "删除产品";
            this.btnDeletePro.UseVisualStyleBackColor = true;
            // 
            // dgvCategoryInfo
            // 
            this.dgvCategoryInfo.AllowUserToAddRows = false;
            this.dgvCategoryInfo.AllowUserToDeleteRows = false;
            this.dgvCategoryInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategoryInfo.BackgroundColor = System.Drawing.Color.Tan;
            this.dgvCategoryInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategoryInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.Column1, this.Column2, this.Column3, this.Column5 });
            this.dgvCategoryInfo.Location = new System.Drawing.Point(24, 15);
            this.dgvCategoryInfo.Margin = new System.Windows.Forms.Padding(6);
            this.dgvCategoryInfo.Name = "dgvCategoryInfo";
            this.dgvCategoryInfo.ReadOnly = true;
            this.dgvCategoryInfo.RowHeadersVisible = false;
            this.dgvCategoryInfo.RowHeadersWidth = 72;
            this.dgvCategoryInfo.RowTemplate.Height = 23;
            this.dgvCategoryInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategoryInfo.Size = new System.Drawing.Size(684, 328);
            this.dgvCategoryInfo.TabIndex = 119;
            this.dgvCategoryInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategoryInfo_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CatId";
            this.Column1.HeaderText = "类别编号";
            this.Column1.MinimumWidth = 9;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CatName";
            this.Column2.HeaderText = "类别名称";
            this.Column2.MinimumWidth = 9;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Remark";
            this.Column3.HeaderText = "类别描述";
            this.Column3.MinimumWidth = 9;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "SubTime";
            this.Column5.HeaderText = "创建时间";
            this.Column5.MinimumWidth = 9;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // btnShowAllProductInfo
            // 
            this.btnShowAllProductInfo.Location = new System.Drawing.Point(720, 65);
            this.btnShowAllProductInfo.Margin = new System.Windows.Forms.Padding(6);
            this.btnShowAllProductInfo.Name = "btnShowAllProductInfo";
            this.btnShowAllProductInfo.Size = new System.Drawing.Size(242, 46);
            this.btnShowAllProductInfo.TabIndex = 129;
            this.btnShowAllProductInfo.Text = "显示所有类别商品";
            this.btnShowAllProductInfo.UseVisualStyleBackColor = true;
            this.btnShowAllProductInfo.Click += new System.EventHandler(this.btnShowAllProductInfo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvProductInfo);
            this.groupBox2.Location = new System.Drawing.Point(18, 355);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(1604, 762);
            this.groupBox2.TabIndex = 125;
            this.groupBox2.TabStop = false;
            // 
            // ProductManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1666, 1166);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.btnUpdatePro);
            this.Controls.Add(this.btnAddPro);
            this.Controls.Add(this.btnUpdateCategory);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.benDeleteCategory);
            this.Controls.Add(this.btnDeletePro);
            this.Controls.Add(this.dgvCategoryInfo);
            this.Controls.Add(this.btnShowAllProductInfo);
            this.Controls.Add(this.groupBox2);
            this.Name = "ProductManager";
            this.Text = "ProductManager";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoryInfo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnUpdatePro;
        private System.Windows.Forms.Button btnAddPro;
        private System.Windows.Forms.Button btnUpdateCategory;
        private System.Windows.Forms.DataGridView dgvProductInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProSpell;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button benDeleteCategory;
        private System.Windows.Forms.Button btnDeletePro;
        private System.Windows.Forms.DataGridView dgvCategoryInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btnShowAllProductInfo;
        private System.Windows.Forms.GroupBox groupBox2;

        #endregion
    }
}