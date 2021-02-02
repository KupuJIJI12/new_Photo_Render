using ImageMagick;

namespace photo_render.Api.Filters
{
    public class ShadeFilter : IFilter
    {
        private string _path;

        public ShadeFilter(string path)
        {
            _path = path;
        }
        public string Filter()
        {
            using (var image = new MagickImage(_path))
            {
                image.Shade();
                //image.Write(result);
                return image.FileName;
            }
        }
    }
}