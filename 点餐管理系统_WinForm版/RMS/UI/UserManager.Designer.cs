namespace UI
{
    partial class UserManager
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.uid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.updateUserButton = new System.Windows.Forms.Button();
            this.deleteUserButton = new System.Windows.Forms.Button();
            this.insertUserButton = new System.Windows.Forms.Button();
            this.positionRadioButton2 = new System.Windows.Forms.RadioButton();
            this.positionRadioButton1 = new System.Windows.Forms.RadioButton();
            this.realnameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.passwordTextBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.userIdTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10F);
            this.groupBox1.Location = new System.Drawing.Point(38, 50);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1024, 616);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "展示员工信息";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uid,
            this.username,
            this.password,
            this.realname,
            this.position});
            this.dataGridView1.Location = new System.Drawing.Point(8, 36);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 72;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(982, 580);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // uid
            // 
            this.uid.DataPropertyName = "uid";
            this.uid.HeaderText = "编号";
            this.uid.MinimumWidth = 9;
            this.uid.Name = "uid";
            this.uid.ReadOnly = true;
            // 
            // username
            // 
            this.username.DataPropertyName = "username";
            this.username.HeaderText = "用户名";
            this.username.MinimumWidth = 9;
            this.username.Name = "username";
            this.username.ReadOnly = true;
            // 
            // password
            // 
            this.password.DataPropertyName = "password";
            this.password.HeaderText = "密码";
            this.password.MinimumWidth = 9;
            this.password.Name = "password";
            this.password.ReadOnly = true;
            // 
            // realname
            // 
            this.realname.DataPropertyName = "realname";
            this.realname.HeaderText = "真实姓名";
            this.realname.MinimumWidth = 9;
            this.realname.Name = "realname";
            this.realname.ReadOnly = true;
            // 
            // position
            // 
            this.position.DataPropertyName = "position";
            this.position.HeaderText = "职位";
            this.position.MinimumWidth = 9;
            this.position.Name = "position";
            this.position.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.updateUserButton);
            this.groupBox2.Controls.Add(this.deleteUserButton);
            this.groupBox2.Controls.Add(this.insertUserButton);
            this.groupBox2.Controls.Add(this.positionRadioButton2);
            this.groupBox2.Controls.Add(this.positionRadioButton1);
            this.groupBox2.Controls.Add(this.realnameTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.passwordTextBox3);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.usernameTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.userIdTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10F);
            this.groupBox2.Location = new System.Drawing.Point(1095, 65);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(502, 616);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作员工信息";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(74, 502);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(394, 24);
            this.label6.TabIndex = 16;
            this.label6.Text = "提示：双击表格可以在此处进行修改";
            // 
            // updateUserButton
            // 
            this.updateUserButton.BackColor = System.Drawing.Color.YellowGreen;
            this.updateUserButton.Location = new System.Drawing.Point(296, 442);
            this.updateUserButton.Margin = new System.Windows.Forms.Padding(4);
            this.updateUserButton.Name = "updateUserButton";
            this.updateUserButton.Size = new System.Drawing.Size(130, 46);
            this.updateUserButton.TabIndex = 15;
            this.updateUserButton.Text = "修改";
            this.updateUserButton.UseVisualStyleBackColor = false;
            // 
            // deleteUserButton
            // 
            this.deleteUserButton.BackColor = System.Drawing.Color.Pink;
            this.deleteUserButton.Font = new System.Drawing.Font("宋体", 10F);
            this.deleteUserButton.Location = new System.Drawing.Point(160, 550);
            this.deleteUserButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteUserButton.Name = "deleteUserButton";
            this.deleteUserButton.Size = new System.Drawing.Size(260, 58);
            this.deleteUserButton.TabIndex = 14;
            this.deleteUserButton.Text = "删除选中的数据";
            this.deleteUserButton.UseVisualStyleBackColor = false;
            // 
            // insertUserButton
            // 
            this.insertUserButton.BackColor = System.Drawing.Color.SandyBrown;
            this.insertUserButton.Location = new System.Drawing.Point(160, 442);
            this.insertUserButton.Margin = new System.Windows.Forms.Padding(4);
            this.insertUserButton.Name = "insertUserButton";
            this.insertUserButton.Size = new System.Drawing.Size(130, 46);
            this.insertUserButton.TabIndex = 12;
            this.insertUserButton.Text = "添加";
            this.insertUserButton.UseVisualStyleBackColor = false;
            // 
            // positionRadioButton2
            // 
            this.positionRadioButton2.AutoSize = true;
            this.positionRadioButton2.Location = new System.Drawing.Point(306, 296);
            this.positionRadioButton2.Margin = new System.Windows.Forms.Padding(4);
            this.positionRadioButton2.Name = "positionRadioButton2";
            this.positionRadioButton2.Size = new System.Drawing.Size(97, 31);
            this.positionRadioButton2.TabIndex = 11;
            this.positionRadioButton2.Text = "经理";
            this.positionRadioButton2.UseVisualStyleBackColor = true;
            // 
            // positionRadioButton1
            // 
            this.positionRadioButton1.AutoSize = true;
            this.positionRadioButton1.Checked = true;
            this.positionRadioButton1.Location = new System.Drawing.Point(178, 296);
            this.positionRadioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.positionRadioButton1.Name = "positionRadioButton1";
            this.positionRadioButton1.Size = new System.Drawing.Size(97, 31);
            this.positionRadioButton1.TabIndex = 10;
            this.positionRadioButton1.TabStop = true;
            this.positionRadioButton1.Text = "员工";
            this.positionRadioButton1.UseVisualStyleBackColor = true;
            // 
            // realnameTextBox
            // 
            this.realnameTextBox.Location = new System.Drawing.Point(160, 364);
            this.realnameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.realnameTextBox.Name = "realnameTextBox";
            this.realnameTextBox.Size = new System.Drawing.Size(260, 38);
            this.realnameTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 376);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 27);
            this.label5.TabIndex = 8;
            this.label5.Text = "真实姓名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 296);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 27);
            this.label4.TabIndex = 6;
            this.label4.Text = "职位：";
            // 
            // passwordTextBox3
            // 
            this.passwordTextBox3.Location = new System.Drawing.Point(160, 214);
            this.passwordTextBox3.Margin = new System.Windows.Forms.Padding(4);
            this.passwordTextBox3.Name = "passwordTextBox3";
            this.passwordTextBox3.Size = new System.Drawing.Size(260, 38);
            this.passwordTextBox3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 218);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "密码：";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(160, 138);
            this.usernameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(260, 38);
            this.usernameTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "用户名：";
            // 
            // userIdTextBox
            // 
            this.userIdTextBox.Location = new System.Drawing.Point(160, 68);
            this.userIdTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.userIdTextBox.Name = "userIdTextBox";
            this.userIdTextBox.ReadOnly = true;
            this.userIdTextBox.Size = new System.Drawing.Size(260, 38);
            this.userIdTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "编号：";
            // 
            // UserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1659, 781);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "UserManager";
            this.Text = "UserManager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserManager_FormClosed);
            this.Load += new System.EventHandler(this.UserManager_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn uid;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn password;
        private System.Windows.Forms.DataGridViewTextBoxColumn realname;
        private System.Windows.Forms.DataGridViewTextBoxColumn position;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button updateUserButton;
        private System.Windows.Forms.Button deleteUserButton;
        private System.Windows.Forms.Button insertUserButton;
        private System.Windows.Forms.RadioButton positionRadioButton2;
        private System.Windows.Forms.RadioButton positionRadioButton1;
        private System.Windows.Forms.TextBox realnameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox passwordTextBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox userIdTextBox;
        private System.Windows.Forms.Label label1;
    }
}