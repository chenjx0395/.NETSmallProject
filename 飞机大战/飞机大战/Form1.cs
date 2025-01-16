using System;
using System.Drawing;
using System.Windows.Forms;
using 飞机大战.Properties;

namespace 飞机大战
{
    public partial class Index : Form
    {
        private readonly Image[] _images = { Resources.bg, Resources.plane, Resources.boss };
        private readonly Background _background;
        private readonly Plane _userPlane;
        private GameState _gameState = GameState.NotStart;
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
            _background = new Background(0, -size.Height, size.Width, size.Height * 2, _images[0], 20, GameState.NotStart);
            // 创建玩家飞机
            _userPlane = new Plane((size.Width / 2) - 25, size.Height - 250, 37, 41, _images[1], 0, GameState.NotStart, 100);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 绘制事件，当游戏开始时，不绘制BOSS飞机和提示词
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Index_Paint(object sender, PaintEventArgs e)
        {
            // 绘制背景图片
            var graphics = e.Graphics;
            _background.Draw(graphics);
            // 绘制玩家飞机
            _userPlane.Draw(graphics);
            if (_gameState == GameState.NotStart)
            {
                // 绘制提示词
                graphics.DrawString("鼠标单击开始游戏", new Font("楷体", 19), Brushes.YellowGreen, 110, _userPlane.Y + 100);
                // 绘制Boss飞机
                new Plane(100, 100, 240, 174, _images[2], 0, GameState.NotStart, 500).Draw(graphics);
            }

        }

        /// <summary>
        /// 如果游戏未开始，点击屏幕，则开始游戏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Index_Click(object sender, EventArgs e)
        {
            _gameState = GameState.Start;
            // 启用定时器来不停重新调用绘图事件
            timer1.Enabled = true;
        }
        /// <summary>
        /// 不停的触发重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            // 手动触发重绘
            Invalidate();
            _background.State = GameState.Start;
        }
        /// <summary>
        /// 鼠标移动，调整玩家飞机的位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Index_MouseMove(object sender, MouseEventArgs e)
        {
            if (_gameState == GameState.Start)
            {
                Cursor.Hide();
                _userPlane.X = e.X - _userPlane.Width / 2;
                _userPlane.Y = e.Y - _userPlane.Height / 2;
            }
        }
    }
}
