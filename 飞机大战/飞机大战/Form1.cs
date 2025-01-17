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
        // 弹幕
        private readonly List<Shell> _shell = new List<Shell>();
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
                // 绘制所有子弹
                for (var i = 0; i < _shell.Count; i++)
                {
                    var shell = _shell[i];
                    // 将超出屏幕的子弹删除
                    if (shell.Destroy(Height))
                    {
                        _shell.Remove(shell);
                        continue;
                    }
                    shell.Draw(graphics);
                }
                // 绘制所有敌方飞机1号
                for (var i = 0; i < _plane1.Count; i++)
                {
                    var plane = _plane1[i];
                    // 将超出屏幕的飞机删除
                    if (plane.Y > Height)
                    {
                        _plane1.Remove(plane);
                        continue;
                    }
                    plane.Draw(graphics);
                }
                // 绘制所有敌方飞机2号
                for (var i = 0; i < _plane2.Count; i++)
                {
                    var plane = _plane2[i];
                    // 将超出屏幕的飞机删除
                    if (plane.Y > Height)
                    {
                        _plane2.Remove(plane);
                        continue;
                    }
                    plane.Draw(graphics);
                }
                // 绘制所有boss1号
                for (var i = 0; i < _boss1.Count; i++)
                {
                    var plane = _boss1[i];
                    // 将超出屏幕的飞机删除
                    if (plane.Y > Height)
                    {
                        _boss1.Remove(plane);
                        continue;
                    }
                    plane.Draw(graphics);
                }
                // 绘制所有boss2号
                for (var i = 0; i < _boss2.Count; i++)
                {
                    var plane = _boss2[i];
                    // 将超出屏幕的飞机删除
                    if (plane.Y > Height)
                    {
                        _boss2.Remove(plane);
                        continue;
                    }
                    plane.Draw(graphics);
                }
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
            _shell.Add(new Shell(_userPlane.X + _userPlane.Width / 2, _userPlane.Y - 10, 14, 29, _images[3], 10, GameState.Start));
        }

        private void CreateEnemyPlane1_Tick(object sender, EventArgs e)
        {
            var x = _random.Next(0, Width - 32);
            var plane = new Plane(x, 0, 32, 24, _images[4], 5, GameState.EnemyPlane, 30);
            _plane1.Add(plane);

        }

        private void CreateEnemyPlane2_Tick(object sender, EventArgs e)
        {
            var x = _random.Next(0, Width - 44);
            var plane = new Plane(x, 0, 44, 67, _images[5], 5, GameState.EnemyPlane, 50);
            _plane2.Add(plane);
        }

        private void CreateEnemyPlane2Shell_Tick(object sender, EventArgs e)
        {
            foreach (var plane in _plane2)
            {
                _shell.Add(new Shell(plane.X + (plane.Width /2 - 5) , plane.Y + plane.Height, 14, 25, _images[6], 10, GameState.EnemyPlane));
            }
        }

        private void CreateBoss1_Tick(object sender, EventArgs e)
        {
            var x = _random.Next(0, Width - 172);
            var plane = new Plane(x, 0, 172, 112, _images[8], 5, GameState.EnemyPlane, 300);
            _boss1.Add(plane);
        }

        private void CreateBoss1Shell_Tick(object sender, EventArgs e)
        {
            foreach (var plane in _boss1)
            {
                _shell.Add(new Shell(plane.X + (plane.Width / 2 - 5), plane.Y + plane.Height, 14, 25, _images[9], 15, GameState.EnemyPlane));
            }
        }

        private void CreateBoss2_Tick(object sender, EventArgs e)
        {
            var x = _random.Next(0, Width - 172);
            var plane = new Plane(x, 0, 172, 112, _images[10], 5, GameState.EnemyPlane, 500);
            _boss2.Add(plane);
        }

        private void CreateBoss2Shel_Tick(object sender, EventArgs e)
        {
            foreach (var plane in _boss2)
            {
                _shell.Add(new Shell(plane.X + (plane.Width / 2 - 5), plane.Y + plane.Height, 21, 59, _images[15], 15, GameState.EnemyPlane));
            }
        }
    }
}
