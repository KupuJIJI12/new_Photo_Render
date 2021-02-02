using System.Drawing;
using System.IO;
using System.Windows.Controls;
using ImageMagick;
using photo_render.Api.Filters;
using Bmp = System.Drawing.Bitmap;

namespace photo_render.Api
{
    public class PhotoRender
    {
        private PhotoRender() { }
        private static PhotoRender _instance;
        private bool _isChanged;

        public static PhotoRender GetInstance() => _instance ??= new PhotoRender();

        public string Render(IFilter filter)
        {
            /*if (_isChanged)
                File.Delete("pic.png");
            _isChanged = true;*/
            return filter.Filter();
        }
    }
}