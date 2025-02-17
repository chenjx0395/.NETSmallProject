using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    partial class CategoryInfoInsertOrUpdate
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtCid = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.registDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labId = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkKhaki;
            this.button1.Location = new System.Drawing.Point(233, 384);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(300, 80);
            this.button1.TabIndex = 320;
            this.button1.Text = "提交";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCid
            // 
            this.txtCid.Location = new System.Drawing.Point(233, 44);
            this.txtCid.Margin = new System.Windows.Forms.Padding(6);
            this.txtCid.Name = "txtCid";
            this.txtCid.ReadOnly = true;
            this.txtCid.Size = new System.Drawing.Size(300, 35);
            this.txtCid.TabIndex = 321;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(85, 52);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 24);
            this.label13.TabIndex = 318;
            this.label13.Text = "类名编号:";
            // 
            // registDate
            // 
            this.registDate.Location = new System.Drawing.Point(233, 298);
            this.registDate.Margin = new System.Windows.Forms.Padding(6);
            this.registDate.Name = "registDate";
            this.registDate.Size = new System.Drawing.Size(300, 35);
            this.registDate.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(385, 268);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 316;
            this.label1.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(81, 306);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 24);
            this.label10.TabIndex = 315;
            this.label10.Text = "添加日期:";
            // 
            // labId
            // 
            this.labId.AutoSize = true;
            this.labId.Location = new System.Drawing.Point(397, 268);
            this.labId.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labId.Name = "labId";
            this.labId.Size = new System.Drawing.Size(0, 24);
            this.labId.TabIndex = 314;
            this.labId.Visible = false;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(233, 210);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(6);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(300, 35);
            this.txtDesc.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 214);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 24);
            this.label5.TabIndex = 311;
            this.label5.Text = "类别描述:";
            // 
            // txtCname
            // 
            this.txtCname.Location = new System.Drawing.Point(233, 128);
            this.txtCname.Margin = new System.Windows.Forms.Padding(6);
            this.txtCname.Name = "txtCname";
            this.txtCname.Size = new System.Drawing.Size(300, 35);
            this.txtCname.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 24);
            this.label2.TabIndex = 310;
            this.label2.Text = "类别名称:";
            // 
            // CategoryInfoInsertOrUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 552);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCid);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.registDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labId);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCname);
            this.Controls.Add(this.label2);
            this.Name = "CategoryInfoInsertOrUpdate";
            this.Text = "ProductInfoInsertOrUpdate";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCid;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker registDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labId;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCname;
        private System.Windows.Forms.Label label2;

        #endregion
    }
}