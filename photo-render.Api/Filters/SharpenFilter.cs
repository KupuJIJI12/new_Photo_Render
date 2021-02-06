using ImageMagick;

namespace photo_render.Api.Filters
{
    public class SharpenFilter : IFilter
    {
        public string Filter(string path)
        {
            using (var image = new MagickImage(path))
            {
                image.Sharpen(5, 5);
                return FilterProcess.GetResult(image);
            }
        }
    }
}