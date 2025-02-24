using System;
using System.Windows.Forms;
using Common;
using HospitalManagementSystem.SystemManagement;

namespace HospitalManagementSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // 启动时权限验证
            try
            {
                new PermissionSyncService().ValidatePermissions();
            }
            catch (Exception ex)
            {
                // ReSharper disable once LocalizableElement
                MessageBox.Show($"权限配置错误：\n{ex.Message}", @"系统启动失败", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            Application.Run(new Login());
            //TODO 测试使用
            // Application.Run(new MainPage());
            // Application.Run(new PermissionManagementForm());
            
        }
    }
}