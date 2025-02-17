using System;
using System.Windows.Forms;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new OrderingLogin());
            // TODO 生产环境测试界面使用
            Application.Run(new OrderingMain());
        }
    }
}
