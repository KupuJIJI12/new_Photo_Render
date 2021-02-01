using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace photo_render.Api.Bitmap
{
    public static class BitmapSourceConverter
    {
        public static BitmapSource ToBitmapSource(this System.Drawing.Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);

            var bitmapSource = BitmapSource.Create(
                bitmapData.Width, bitmapData.Height,
                bitmap.HorizontalResolution, bitmap.VerticalResolution,
                PixelFormats.Bgra32, null, // формат Bgra32 тоже работает исправно
                bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);

            bitmap.UnlockBits(bitmapData);
            return bitmapSource;
        }
    }
}