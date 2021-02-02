using System.Windows.Controls;
using photo_render.Api.Filters;
using Bmp = System.Drawing.Bitmap;

namespace photo_render.Api.Bitmap
{
    public class PhotoRender
    {
        private PhotoRender() { }
        private static PhotoRender _instance;

        public static PhotoRender GetInstance() => _instance ??= new PhotoRender();

        public Bmp Render(IFilter filter) => filter.Filter();
    }
}