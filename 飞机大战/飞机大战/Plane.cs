using System.Drawing;
using Image = System.Drawing.Image;

namespace 飞机大战
{
    internal class Plane
    {
        public int X { get; set; }
        public int Y { get; set; }
        // 长
        public int Length { get; set; }
        // 宽
        public int Width { get; set; }
        public Image PlaneImage { get; set; }

        public Plane()
        {
        }

        public Plane(int x, int y, int length, int width, Image planeImage)
        {
            X = x;
            Y = y;
            Length = length;
            Width = width;
            PlaneImage = planeImage;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(PlaneImage, new Rectangle(X, Y, Width, Length));

        }
    }
}
