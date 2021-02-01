using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Bmp = System.Drawing.Bitmap;

namespace photo_render.Api.Bitmap
{
    public static class ImageConverter
    {
        public static Bmp ToBitmap(this Image image)
        {
            /*if(image.Source == null) 
                throw new Exceptions.OriginalImageDontExistException("добавьте редактируемую фотографию");*/
            
            var rtBmp = new RenderTargetBitmap((int)image.ActualWidth, (int)image.ActualHeight, 96.0, 96.0, PixelFormats.Pbgra32);

            image.Measure(new System.Windows.Size((int)image.ActualWidth, (int)image.ActualHeight));
            image.Arrange(new Rect(new System.Windows.Size((int)image.ActualWidth, (int)image.ActualHeight)));

            rtBmp.Render(image);

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(rtBmp));

            var stream = new MemoryStream();
            encoder.Save(stream);

            return new Bmp(stream);
        }
    }
}