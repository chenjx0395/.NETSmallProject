﻿namespace 飞机大战
{
    partial class Index
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
            this.components = new System.ComponentModel.Container();
            this.Redraw = new System.Windows.Forms.Timer(this.components);
            this.CreateUserPlaneShell = new System.Windows.Forms.Timer(this.components);
            this.CreateEnemyPlane1 = new System.Windows.Forms.Timer(this.components);
            this.CreateEnemyPlane2 = new System.Windows.Forms.Timer(this.components);
            this.CreateEnemyPlane2Shell = new System.Windows.Forms.Timer(this.components);
            this.CreateBoss1 = new System.Windows.Forms.Timer(this.components);
            this.CreateBoss1Shell = new System.Windows.Forms.Timer(this.components);
            this.CreateBoss2 = new System.Windows.Forms.Timer(this.components);
            this.CreateBoss2Shell = new System.Windows.Forms.Timer(this.components);
            this.CheckCollision = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Redraw
            // 
            this.Redraw.Interval = 50;
            this.Redraw.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CreateUserPlaneShell
            // 
            this.CreateUserPlaneShell.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // CreateEnemyPlane1
            // 
            this.CreateEnemyPlane1.Tick += new System.EventHandler(this.CreateEnemyPlane1_Tick);
            // 
            // CreateEnemyPlane2
            // 
            this.CreateEnemyPlane2.Tick += new System.EventHandler(this.CreateEnemyPlane2_Tick);
            // 
            // CreateEnemyPlane2Shell
            // 
            this.CreateEnemyPlane2Shell.Tick += new System.EventHandler(this.CreateEnemyPlane2Shell_Tick);
            // 
            // CreateBoss1
            // 
            this.CreateBoss1.Tick += new System.EventHandler(this.CreateBoss1_Tick);
            // 
            // CreateBoss1Shell
            // 
            this.CreateBoss1Shell.Tick += new System.EventHandler(this.CreateBoss1Shell_Tick);
            // 
            // CreateBoss2
            // 
            this.CreateBoss2.Tick += new System.EventHandler(this.CreateBoss2_Tick);
            // 
            // CreateBoss2Shell
            // 
            this.CreateBoss2Shell.Tick += new System.EventHandler(this.CreateBoss2Shel_Tick);
            // 
            // CheckCollision
            // 
            this.CheckCollision.Tick += new System.EventHandler(this.CheckCollision_Tick);
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(972, 996);
            this.DoubleBuffered = true;
            this.Name = "Index";
            this.Text = "飞机大战";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Index_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Index_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Index_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Redraw;
        private System.Windows.Forms.Timer CreateUserPlaneShell;
        private System.Windows.Forms.Timer CreateEnemyPlane1;
        private System.Windows.Forms.Timer CreateEnemyPlane2;
        private System.Windows.Forms.Timer CreateEnemyPlane2Shell;
        private System.Windows.Forms.Timer CreateBoss1;
        private System.Windows.Forms.Timer CreateBoss1Shell;
        private System.Windows.Forms.Timer CreateBoss2;
        private System.Windows.Forms.Timer CreateBoss2Shell;
        private System.Windows.Forms.Timer CheckCollision;
    }
}

