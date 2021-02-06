using ImageMagick;

namespace photo_render.Api.Filters
{
    public class NegativeFilter : IFilter
    {
        public string Filter(string path)
        {
            using (var image = new MagickImage(path))
            {
                image.Negate();
                return FilterProcess.GetResult(image);
            }
        }
    }
}