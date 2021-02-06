using ImageMagick;

namespace photo_render.Api.Filters
{
    public class NormalizeFilter : IFilter
    {
        public string Filter(string path)
        {
            using (var image = new MagickImage(path))
            {
                image.Normalize();
                return FilterProcess.GetResult(image);
            }
        }
    }
}