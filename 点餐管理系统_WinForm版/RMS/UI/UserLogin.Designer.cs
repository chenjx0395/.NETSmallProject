namespace UI
{
    partial class UserLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserLogin));
            this.LoginPrompLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.loginBtn = new System.Windows.Forms.Button();
            this.pwdTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.unameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoginPrompLabel
            // 
            this.LoginPrompLabel.AutoSize = true;
            this.LoginPrompLabel.Font = new System.Drawing.Font("宋体", 12F);
            this.LoginPrompLabel.Location = new System.Drawing.Point(614, 606);
            this.LoginPrompLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LoginPrompLabel.Name = "LoginPrompLabel";
            this.LoginPrompLabel.Size = new System.Drawing.Size(0, 33);
            this.LoginPrompLabel.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(747, 659);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(373, 30);
            this.label3.TabIndex = 32;
            this.label3.Text = "提示：请使用经理账号登录";
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.Goldenrod;
            this.loginBtn.Font = new System.Drawing.Font("宋体", 13F);
            this.loginBtn.Location = new System.Drawing.Point(589, 495);
            this.loginBtn.Margin = new System.Windows.Forms.Padding(4);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(304, 82);
            this.loginBtn.TabIndex = 31;
            this.loginBtn.Text = "登录";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // pwdTextBox
            // 
            this.pwdTextBox.Font = new System.Drawing.Font("宋体", 13F);
            this.pwdTextBox.Location = new System.Drawing.Point(589, 359);
            this.pwdTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.pwdTextBox.Name = "pwdTextBox";
            this.pwdTextBox.PasswordChar = '*';
            this.pwdTextBox.Size = new System.Drawing.Size(304, 47);
            this.pwdTextBox.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("宋体", 15F);
            this.label2.Location = new System.Drawing.Point(431, 367);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 40);
            this.label2.TabIndex = 29;
            this.label2.Text = "密码：";
            // 
            // unameTextBox
            // 
            this.unameTextBox.Font = new System.Drawing.Font("宋体", 13F);
            this.unameTextBox.Location = new System.Drawing.Point(589, 223);
            this.unameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.unameTextBox.Name = "unameTextBox";
            this.unameTextBox.Size = new System.Drawing.Size(304, 47);
            this.unameTextBox.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(393, 231);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 40);
            this.label1.TabIndex = 27;
            this.label1.Text = "用户名：";
            // 
            // UserLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1407, 906);
            this.Controls.Add(this.LoginPrompLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.pwdTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.unameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "UserLogin";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserLogin_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LoginPrompLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.TextBox pwdTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox unameTextBox;
        private System.Windows.Forms.Label label1;
    }
}

