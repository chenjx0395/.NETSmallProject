using System.Drawing;

namespace 飞机大战
{

    public class Background : Game ,IMove
    {

        public Background(int x, int y, int width, int height, Image image, int speed, GameState state) : base(x, y, width, height, image, speed, state)
        {

        }
        // 背景移动
        public void Move()
        {
            if (Y + Speed >= 0)
            {
                Y = -(Height / 2);
            }
            Y += Speed;
        }
        /// <summary>
        /// 画游戏页面                                                                                                                                                                                                
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            if (State == GameState.Start) Move();
            g.DrawImage(Image, new Rectangle(X, Y, Width, Height));

        }

    }
}