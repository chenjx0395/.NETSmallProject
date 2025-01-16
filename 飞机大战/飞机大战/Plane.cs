using System.Drawing;
using Image = System.Drawing.Image;

namespace 飞机大战
{
    internal class Plane : Game
    {
        public int Life { get; set; }
        public Plane(int x, int y, int width, int height, Image images, int speed, GameState state, int life) : base(x, y, width, height, images, speed, state)
        {
            this.Life = life;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(Image, new Rectangle(X, Y, Width, Height));

        }
    }
}
