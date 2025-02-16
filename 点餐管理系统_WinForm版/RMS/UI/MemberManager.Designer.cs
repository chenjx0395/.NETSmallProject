namespace UI
{
    partial class MemberManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dgvMemmber = new System.Windows.Forms.DataGridView();
            this.mid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.money = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.points = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemoveFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdateMember = new System.Windows.Forms.Button();
            this.btnAddMemMber = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemmber)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(15, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2002, 964);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.SeaGreen;
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage1.Size = new System.Drawing.Size(1986, 917);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "会员基本信息";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.dgvMemmber);
            this.panel2.Location = new System.Drawing.Point(12, 114);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1976, 798);
            this.panel2.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1286, 698);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(303, 86);
            this.button3.TabIndex = 2;
            this.button3.Text = "下一页";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(380, 698);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(303, 86);
            this.button2.TabIndex = 1;
            this.button2.Text = "上一页";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dgvMemmber
            // 
            this.dgvMemmber.AllowUserToAddRows = false;
            this.dgvMemmber.AllowUserToDeleteRows = false;
            this.dgvMemmber.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMemmber.BackgroundColor = System.Drawing.Color.Sienna;
            this.dgvMemmber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMemmber.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mid,
            this.mname,
            this.gender,
            this.type,
            this.discount,
            this.money,
            this.points,
            this.birthday,
            this.phoneNum,
            this.registDate,
            this.endDate,
            this.RemoveFlag});
            this.dgvMemmber.Location = new System.Drawing.Point(2, 6);
            this.dgvMemmber.Margin = new System.Windows.Forms.Padding(6);
            this.dgvMemmber.MultiSelect = false;
            this.dgvMemmber.Name = "dgvMemmber";
            this.dgvMemmber.ReadOnly = true;
            this.dgvMemmber.RowHeadersVisible = false;
            this.dgvMemmber.RowHeadersWidth = 72;
            this.dgvMemmber.RowTemplate.Height = 23;
            this.dgvMemmber.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMemmber.Size = new System.Drawing.Size(1974, 668);
            this.dgvMemmber.TabIndex = 0;
            // 
            // mid
            // 
            this.mid.DataPropertyName = "mid";
            this.mid.HeaderText = "编号";
            this.mid.MinimumWidth = 9;
            this.mid.Name = "mid";
            this.mid.ReadOnly = true;
            // 
            // mname
            // 
            this.mname.DataPropertyName = "mname";
            this.mname.HeaderText = "会员姓名";
            this.mname.MinimumWidth = 9;
            this.mname.Name = "mname";
            this.mname.ReadOnly = true;
            // 
            // gender
            // 
            this.gender.DataPropertyName = "gender";
            this.gender.HeaderText = "性别";
            this.gender.MinimumWidth = 9;
            this.gender.Name = "gender";
            this.gender.ReadOnly = true;
            // 
            // type
            // 
            this.type.DataPropertyName = "type";
            this.type.HeaderText = "会员等级";
            this.type.MinimumWidth = 9;
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // discount
            // 
            this.discount.DataPropertyName = "discount";
            this.discount.HeaderText = "会员折扣";
            this.discount.MinimumWidth = 9;
            this.discount.Name = "discount";
            this.discount.ReadOnly = true;
            // 
            // money
            // 
            this.money.DataPropertyName = "money";
            this.money.HeaderText = "卡内余额";
            this.money.MinimumWidth = 9;
            this.money.Name = "money";
            this.money.ReadOnly = true;
            // 
            // points
            // 
            this.points.DataPropertyName = "points";
            this.points.HeaderText = "当前积分";
            this.points.MinimumWidth = 9;
            this.points.Name = "points";
            this.points.ReadOnly = true;
            // 
            // birthday
            // 
            this.birthday.DataPropertyName = "birthday";
            this.birthday.HeaderText = "生日";
            this.birthday.MinimumWidth = 9;
            this.birthday.Name = "birthday";
            this.birthday.ReadOnly = true;
            // 
            // phoneNum
            // 
            this.phoneNum.DataPropertyName = "phoneNum";
            this.phoneNum.HeaderText = "电话";
            this.phoneNum.MinimumWidth = 9;
            this.phoneNum.Name = "phoneNum";
            this.phoneNum.ReadOnly = true;
            // 
            // registDate
            // 
            this.registDate.DataPropertyName = "registDate";
            this.registDate.HeaderText = "登记日期";
            this.registDate.MinimumWidth = 9;
            this.registDate.Name = "registDate";
            this.registDate.ReadOnly = true;
            // 
            // endDate
            // 
            this.endDate.DataPropertyName = "endDate";
            this.endDate.HeaderText = "截至日期";
            this.endDate.MinimumWidth = 9;
            this.endDate.Name = "endDate";
            this.endDate.ReadOnly = true;
            // 
            // RemoveFlag
            // 
            this.RemoveFlag.DataPropertyName = "removeFlag";
            this.RemoveFlag.HeaderText = "是否被删除";
            this.RemoveFlag.MinimumWidth = 10;
            this.RemoveFlag.Name = "RemoveFlag";
            this.RemoveFlag.ReadOnly = true;
            this.RemoveFlag.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnUpdateMember);
            this.panel1.Controls.Add(this.btnAddMemMber);
            this.panel1.Location = new System.Drawing.Point(12, 18);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1970, 90);
            this.panel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1798, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 68);
            this.button1.TabIndex = 7;
            this.button1.Text = "回收站";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(798, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "编号/姓名:";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("宋体", 10F);
            this.button5.Location = new System.Drawing.Point(1250, 20);
            this.button5.Margin = new System.Windows.Forms.Padding(6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 46);
            this.button5.TabIndex = 5;
            this.button5.Text = "查找";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 10F);
            this.textBox1.Location = new System.Drawing.Point(946, 24);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(288, 38);
            this.textBox1.TabIndex = 4;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(428, 6);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 68);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdateMember
            // 
            this.btnUpdateMember.Location = new System.Drawing.Point(212, 6);
            this.btnUpdateMember.Margin = new System.Windows.Forms.Padding(6);
            this.btnUpdateMember.Name = "btnUpdateMember";
            this.btnUpdateMember.Size = new System.Drawing.Size(150, 68);
            this.btnUpdateMember.TabIndex = 1;
            this.btnUpdateMember.Text = "修改";
            this.btnUpdateMember.UseVisualStyleBackColor = true;
            // 
            // btnAddMemMber
            // 
            this.btnAddMemMber.Location = new System.Drawing.Point(6, 4);
            this.btnAddMemMber.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddMemMber.Name = "btnAddMemMber";
            this.btnAddMemMber.Size = new System.Drawing.Size(150, 68);
            this.btnAddMemMber.TabIndex = 0;
            this.btnAddMemMber.Text = "增加";
            this.btnAddMemMber.UseVisualStyleBackColor = true;
            // 
            // MemberManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2162, 1430);
            this.Controls.Add(this.tabControl1);
            this.Name = "MemberManager";
            this.Text = "MemberManager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MemberManager_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemmber)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvMemmber;
        private System.Windows.Forms.DataGridViewTextBoxColumn mid;
        private System.Windows.Forms.DataGridViewTextBoxColumn mname;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn money;
        private System.Windows.Forms.DataGridViewTextBoxColumn points;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn registDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn RemoveFlag;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdateMember;
        private System.Windows.Forms.Button btnAddMemMber;
    }
}