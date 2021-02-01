using System;
using System.Drawing;
using Bmp = System.Drawing.Bitmap;

namespace photo_render.Api.Bitmap
{
    public static class BitmapConverter
    {
        private const int ResizeRate = 2;

        private static Bmp ToBitmap(int width, int height, Func<int, int, Color> getPixelColor)
        {
            var bmp = new Bmp(ResizeRate * width, ResizeRate * height);
            using (var g = Graphics.FromImage(bmp))
            {
                for (var x = 0; x < width; x++)
                for (var y = 0; y < height; y++)
                    g.FillRectangle(new SolidBrush(getPixelColor(x, y)),
                        ResizeRate * x,
                        ResizeRate * y,
                        ResizeRate,
                        ResizeRate
                    );
            }

            return bmp;
        }
        
        public static Bmp ToBitmap(this Pixel[,] array)
        {
            return ToBitmap(array.GetLength(0), array.GetLength(1),
                (x, y) => Color.FromArgb((byte)array[x, y].Red, (byte)array[x, y].Green, (byte)array[x, y].Blue));
        }

        public static Bmp ToBitmap(this double[,] array)
        {
            return ToBitmap(array.GetLength(0), array.GetLength(1), (x, y) =>
            {
                var gray = (int)(255 * array[x, y]);
                gray = Math.Min(gray, 255);
                gray = Math.Max(gray, 0);
                return Color.FromArgb(gray, gray, gray);
            });
        }
    }
}