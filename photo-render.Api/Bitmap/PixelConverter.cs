using Bmp = System.Drawing.Bitmap;

namespace photo_render.Api.Bitmap
{
    public static class PixelConverter
    {
        public static Pixel[,] LoadPixels(this Bmp bmp)
        {
            var pixels = new Pixel[bmp.Width, bmp.Height];
            for (var x = 0; x < bmp.Width; x++)
            for (var y = 0; y < bmp.Height; y++)
                pixels[x, y] = new Pixel(bmp.GetPixel(x, y));
            return pixels;
        }     
    }
}