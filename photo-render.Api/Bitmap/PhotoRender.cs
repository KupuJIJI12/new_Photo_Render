using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Imaging;
using photo_render.Api.Filters;
using Bmp = System.Drawing.Bitmap;
using Image = System.Drawing.Image;

namespace photo_render.Api
{
    public class PhotoRender
    {
        private PhotoRender() { }
        private static PhotoRender _instance;

        public static PhotoRender GetInstance() => _instance ??= new PhotoRender();

        public BitmapSource Render(IFilter filter)
        {
            try
            {
                return ImageToBitmapSource(filter.Filter());
            }
            catch (Exception exception)
            {
                MessageBox.Show("Добавьте редактируемое изображение");
            }

            return new BitmapImage();
        } 

        private static BitmapSource ImageToBitmapSource(Image image) => BitmapToBitmapSource(new Bmp(image));

        private static BitmapSource BitmapToBitmapSource(Bmp source)
        {
            BitmapSource bitSrc;

            try
            {
                bitSrc = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    source.GetHbitmap(),
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            }
            catch (Win32Exception)
            {
                bitSrc = null;
            }

            return bitSrc;
        }
    }
}