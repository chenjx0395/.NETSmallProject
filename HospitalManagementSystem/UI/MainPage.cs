using System;
using System.Windows.Forms;
using HospitalManagementSystem.SystemManagement;

namespace HospitalManagementSystem
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
            // 无边框
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
        }

        //打开系统管理页面事件
        private void button1_Click(object sender, EventArgs e)
        {
            var smIndex = new SMIndex();
            smIndex.TopLevel = false;
            panelContent.Controls.Add(smIndex);
            //填充整个面板
            smIndex.Dock = DockStyle.Fill;
            smIndex.Size = panelContent.ClientSize; // 显式设置尺寸
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            smIndex.PerformLayout();
            panelContent.PerformLayout();

            smIndex.Show();
        }
    }
}