using System;
using System.Windows.Media.Imaging;
using photo_render.Api.Filters;

namespace photo_render.Api
{
    public class PhotoRender
    {
        private PhotoRender() { }
        private static PhotoRender _instance;

        public static PhotoRender GetInstance() => _instance ??= new PhotoRender();

        public BitmapSource Render(IFilter filter)
        {
            return new BitmapImage(new Uri(filter.Filter()));
        }
    }
}