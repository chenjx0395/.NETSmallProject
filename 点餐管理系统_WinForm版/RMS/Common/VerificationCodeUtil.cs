using System;
using System.Drawing;

namespace Common
{
    public static class VerificationCodeUtil
    {
        public static string Code;
        public static Bitmap GetCode()
        {
            var bitmap = new Bitmap(140, 40);
            var graphics = Graphics.FromImage(bitmap);
            Color[] colors = { Color.Black, Color.Red, Color.Green, Color.Blue, Color.Coral, Color.HotPink };
            var random = new Random();
            Code = "";
            //创建5位验证码
            for (var i = 0; i < 4; i++)
            {
                var v = random.Next(0, 10).ToString();
                Code += v;
                graphics.DrawString(v, new Font("楷体", 16f), new SolidBrush(colors[random.Next(0, 6)]), new PointF(i * 15 + 7, random.Next(0, 8)));
            }

            //创建干扰线
            for (var i = 0; i < 10; i++)
            {
                graphics.DrawLine(new Pen(colors[random.Next(0, 6)], 1), new Point(random.Next(0, bitmap.Width), random.Next(0, bitmap.Height)), new Point(random.Next(0, bitmap.Width), random.Next(0, bitmap.Height)));
            }

            //创建像素点
            for (var i = 0; i < 500; i++)
            {
                bitmap.SetPixel(random.Next(0, bitmap.Width), random.Next(0, bitmap.Height), colors[random.Next(0, 6)]);
            }

            return bitmap;
        }
    }
}