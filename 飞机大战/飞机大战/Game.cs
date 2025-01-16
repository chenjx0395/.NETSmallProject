using static System.Windows.Forms.AxHost;
using System.Drawing;

namespace 飞机大战
{
    public class Game
    {
        //X轴坐标
        public int X { get; set; }
        //Y轴坐标
        public int Y { get; set; }
        //宽度
        public int Width { get; set; }
        //高度
        public int Height { get; set; }
        //图片
        public Image Image { get; set; }
        //变化速度（每次移动的距离）
        public int Speed { get; set; }
        //状态
        public GameState State { get; set; }

        public Game(int x, int y, int width, int height, Image image, int speed, GameState state)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Image = image;
            Speed = speed;
            State = state;
        }

        public virtual void Draw(Graphics graphics) { }
    }
}