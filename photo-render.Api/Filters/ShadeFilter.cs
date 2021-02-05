using ImageMagick;

namespace photo_render.Api.Filters
{
    public class ShadeFilter : IFilter
    {
        public string Filter(string path)
        {
            using (var image = new MagickImage(path))
            {
                image.Shade();
                return FilterProcess.GetResult(image);
            }
        }
    }
}