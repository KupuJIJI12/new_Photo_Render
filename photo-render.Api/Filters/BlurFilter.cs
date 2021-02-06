using ImageMagick;

namespace photo_render.Api.Filters
{
    public class BlurFilter : IFilter
    {
        public string Filter(string path)
        {
            using (var image = new MagickImage(path))
            {
                image.Blur(3, 5);
                return FilterProcess.GetResult(image);
            }
        }
    }
}