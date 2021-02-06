using ImageMagick;

namespace photo_render.Api.Filters
{
    public class GrayscaleFilter : IFilter
    {
        public string Filter(string path)
        {
            using (var image = new MagickImage(path))
            {
                image.Grayscale();
                return FilterProcess.GetResult(image);
            }
        }
    }
}