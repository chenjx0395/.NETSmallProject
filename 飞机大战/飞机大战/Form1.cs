using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using 飞机大战.Properties;

namespace 飞机大战
{
    public partial class Index : Form
    {
        private readonly Image[] _images =
        {
            Resources.bg, Resources.plane, Resources.boss ,Resources.shell
            ,Resources.enemy1, Resources.enemy2, Resources.enemy2bullet,
            Resources.gift, Resources.littleboss1, Resources.littleboss1bullet,
            Resources.littleboss2, Resources.plane, Resources.shell, Resources.doubleshell,
            Resources.tripleshell, Resources.littleboss2bullet
        };

        private readonly Random _random = new Random();
        private readonly Background _background;
        private readonly Plane _userPlane;
        private GameState _gameState = GameState.NotStart;
        // 用户飞机弹幕
        private readonly List<Shell> _userShells = new List<Shell>();
        // 敌方飞机弹幕
        private readonly List<Shell> _enemyShells = new List<Shell>();
        // 敌方飞机1号
        private readonly List<Plane> _plane1 = new List<Plane>();
        // 敌方飞机2号
        private readonly List<Plane> _plane2 = new List<Plane>();
        // boss1和2
        private readonly List<Plane> _boss1 = new List<Plane>();
        private readonly List<Plane> _boss2 = new List<Plane>();
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
            _background = new Background(0, -size.Height, size.Width, size.Height * 2, _images[0], 10, GameState.NotStart);
            // 创建玩家飞机
            _userPlane = new Plane((size.Width / 2) - 25, size.Height - 250, 37, 41, _images[1], 0, GameState.NotStart,
                100);
            //调整用户飞机发射子弹速度
            CreateUserPlaneShell.Interval = 300;
            // 调整生产敌方飞机1号速度
            CreateEnemyPlane1.Interval = 500;
            // 调整生产敌方飞机2号速度
            CreateEnemyPlane2.Interval = 1500;
            CreateEnemyPlane2Shell.Interval = 500;
            // boss1
            CreateBoss1.Interval = 3000;
            CreateBoss1Shell.Interval = 500;
            // boss2
            CreateBoss2.Interval = 5000;
            CreateBoss2Shell.Interval = 500;
        }

        public sealed override Size MinimumSize
        {
            get => base.MinimumSize;
            set => base.MinimumSize = value;
        }

        public sealed override Size MaximumSize
        {
            get => base.MaximumSize;
            set => base.MaximumSize = value;
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
            else
            {
                // 绘制所有用户子弹
                DrawShell(graphics, _userShells);
                // 绘制所有敌方子弹
                DrawShell(graphics, _enemyShells);
                // 绘制所有敌方飞机1号
                DrawPlanes(graphics, _plane1);
                // 绘制所有敌方飞机2号
                DrawPlanes(graphics, _plane2);
                // 绘制所有boss1号
                DrawPlanes(graphics, _boss1);
                // 绘制所有boss2号
                DrawPlanes(graphics, _boss2);
            }

        }

        private void DrawShell(Graphics graphics, List<Shell> shells)
        {
            for (var i = 0; i < shells.Count; i++)
            {
                var shell = shells[i];
                // 将超出屏幕的子弹删除
                if (shell.Destroy(Height))
                {
                    shells.Remove(shell);
                    continue;
                }
                shell.Draw(graphics);
            }
        }

        private void DrawPlanes(Graphics graphics, List<Plane> planes)
        {
            for (var i = 0; i < planes.Count; i++)
            {
                var plane = planes[i];
                // 将超出屏幕的飞机删除
                if (plane.Y > Height)
                {
                    planes.Remove(plane);
                    continue;
                }
                plane.Draw(graphics);
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
            Redraw.Enabled = true;
            // 启用定时器不停创建用户子弹
            CreateUserPlaneShell.Enabled = true;
            // 启用定时器不停创建敌方飞机1号
            CreateEnemyPlane1.Enabled = true;
            // 启用定时器不停创建敌方飞机2号
            CreateEnemyPlane2.Enabled = true;
            // 启用定时器不停创建敌方飞机2号子弹
            CreateEnemyPlane2Shell.Enabled = true;
            // 启用定时器不停创建boss1号
            CreateBoss1.Enabled = true;
            CreateBoss1Shell.Enabled = true;
            // 启用定时器不停创建boss2号
            CreateBoss2.Enabled = true;
            CreateBoss2Shell.Enabled = true;
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

        // 产生用户飞机子弹
        private void timer2_Tick(object sender, EventArgs e)
        {
            // 创建一个子弹
            _userShells.Add(new Shell(_userPlane.X + _userPlane.Width / 2, _userPlane.Y - 10, 14, 29, _images[3], 10, GameState.Start));
        }
        private void AddPlane(List<Plane> planes,int width, int height, Image image, int speed, GameState state, int life)
        {
            var x = _random.Next(0, Width - width);
            var plane = new Plane(x, 0, width, height, image, speed, state, life);
            planes.Add(plane);
        }

        private void CreateEnemyPlane1_Tick(object sender, EventArgs e)
        {
            AddPlane(_plane1, 32,24, _images[4],5,GameState.EnemyPlane,10);
        }

        private void CreateEnemyPlane2_Tick(object sender, EventArgs e)
        {
            AddPlane(_plane2,44, 67, _images[5],5,GameState.EnemyPlane,30);
        }

        private void CreateEnemyPlane2Shell_Tick(object sender, EventArgs e)
        {
            foreach (var plane in _plane2)
            {
                _enemyShells.Add(new Shell(plane.X + (plane.Width / 2 - 5), plane.Y + plane.Height, 14, 25, _images[6], 10, GameState.EnemyPlane));
            }
        }

        private void CreateBoss1_Tick(object sender, EventArgs e)
        {
            AddPlane(_boss1, 172, 112, _images[8],5,GameState.EnemyPlane,50);
        }

        private void CreateBoss1Shell_Tick(object sender, EventArgs e)
        {
            foreach (var plane in _boss1)
            {
                _enemyShells.Add(new Shell(plane.X + (plane.Width / 2 - 5), plane.Y + plane.Height, 14, 25, _images[9], 15, GameState.EnemyPlane));
            }
        }

        private void CreateBoss2_Tick(object sender, EventArgs e)
        {
            AddPlane(_boss2, 172, 112, _images[10],5,GameState.EnemyPlane,100);
        }

        private void CreateBoss2Shel_Tick(object sender, EventArgs e)
        {
            foreach (var plane in _boss2)
            {
                _enemyShells.Add(new Shell(plane.X + (plane.Width / 2 - 5), plane.Y + plane.Height, 21, 59, _images[15], 15, GameState.EnemyPlane));
            }
        }
    }
}
