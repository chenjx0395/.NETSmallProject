using System;
using System.Drawing;

namespace 飞机大战
{
    internal class Shell : Game, IMove
    {
        public Shell(int x, int y, int width, int height, Image image, int speed, GameState state) : base(x, y, width, height, image, speed, state)
        {
        }

        //画
        public override void Draw(Graphics g)
        {
            if (State == GameState.Start) Move();
            g.DrawImage(Image, X, Y, Width, Height);
        }
        public void Move()
        {
            Y -= Speed;
        }
        /// <summary>
        ///  子弹销毁判断，如果子弹超出屏幕，则销毁
        /// </summary>
        /// <param name="height">屏幕高度</param>
        /// <returns></returns>
        public bool Destroy(int height)
        {
            return Y < 100;
        }
    }
}
