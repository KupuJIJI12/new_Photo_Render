using System.Drawing;
using System.Windows.Controls;
using ImageMagick;
using photo_render.Api.Filters;
using Bmp = System.Drawing.Bitmap;

namespace photo_render.Api.Bitmap
{
    public class PhotoRender
    {
        private PhotoRender() { }
        private static PhotoRender _instance;

        public static PhotoRender GetInstance() => _instance ??= new PhotoRender();

        public string Render(IFilter filter) => filter.Filter();
        

        /*public string F(string fileName)
        {
            //string result = "";
            
            //return result;
            //image.Grayscale();
            //return image.FileName;
        }*/
    }
}