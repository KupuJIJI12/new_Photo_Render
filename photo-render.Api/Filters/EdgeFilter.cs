using System;
using ImageMagick;

namespace photo_render.Api.Filters
{
    public class EdgeFilter : IFilter
    {
        private readonly string _path;

        public EdgeFilter(string path)
        {
            _path = path;
        }
        public string Filter()
        {
            using (var image = new MagickImage(_path))
            {
                image.Edge(2);
                image.Write("~\\Images");
                return image.FileName;
            }
        }
    }
}