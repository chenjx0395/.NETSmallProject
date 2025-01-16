using System;
using System.Drawing;
using System.Windows.Forms;
using 飞机大战.Properties;

namespace 飞机大战
{
    public partial class Index : Form
    {
        private Image[] _images = { Resources.bg, Resources.plane, Resources.boss };
        private Background _background;
        private Plane _userPlane;
                public Index()
        {
            InitializeComponent();
            // 设置窗口大小，并不允许改变窗口大小，窗口居中
            var size = new Size(450, 750);
            Size = size;
            MaximumSize = size;
            MinimumSize = size;
            StartPosition = FormStartPosition.CenterScreen;
            // 创建背景对象
            _background = new Background(_images[0], 5, size.Height, size.Width);
            // 创建玩家飞机
            _userPlane = new Plane((size.Width / 2) - 25, size.Height - 250, 41, 37, _images[1]);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Index_Paint(object sender, PaintEventArgs e)
        {
            // 绘制背景图片
            var graphics = e.Graphics;
            _background.Draw(graphics);
            // 绘制玩家飞机
            _userPlane.Draw(graphics);
            // 绘制提示词
            graphics.DrawString("鼠标单击开始游戏", new Font("楷体", 19), Brushes.YellowGreen, 110, _userPlane.Y + 100);
            // 绘制Boss飞机
            new Plane(100, 100, 174, 240, _images[2]).Draw(graphics);

        }

        /// <summary>
        /// 如果游戏未开始，点击屏幕，则开始游戏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Index_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 不停的触发重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
