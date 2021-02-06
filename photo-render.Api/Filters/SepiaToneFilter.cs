using ImageMagick;

namespace photo_render.Api.Filters
{
    public class SepiaToneFilter : IFilter
    {
        public string Filter(string path)
        {
            using (var image = new MagickImage(path))
            {
                image.SepiaTone(new Percentage(80));
                return FilterProcess.GetResult(image);
            }
        }
    }
}