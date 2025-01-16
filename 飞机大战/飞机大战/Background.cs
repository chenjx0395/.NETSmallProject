using System.Drawing;

namespace 飞机大战
{

    public class Background
    {
        //背景图片
        public Image BgImage { get; set; }
        // 背景图片的坐标
        public int X { get; set; }
        public int Y { get; set; }
        // 移动速度
        public int Speed { get; set; }
        // 长
        public int Length { get; set; }
        // 宽
        public int Width { get; set; }
        // 背景状态
        public GameState BackgroundStatus { get; set; }

        public Background()
        {
        }
        public Background(Image image, int speed, int length, int width)
        {
            BgImage = image;
            X = 0;
            Y = -(length / 2);
            Speed = speed;
            // 背景移动
            Length = length * 2;
            Width = width;
            BackgroundStatus = GameState.NotStart;
        }
        // 背景移动
        private void Move()
        {
            if (Y + Speed >= 0)
            {
                Y = -(Length / 2);
            }
            Y += Speed;
        }
        /// <summary>
        /// 画游戏页面
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            if (BackgroundStatus == GameState.Start) Move();
            g.DrawImage(BgImage, new Rectangle(X, Y, Width, Length));

        }

    }
}