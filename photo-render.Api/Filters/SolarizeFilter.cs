using ImageMagick;

namespace photo_render.Api.Filters
{
    public class SolarizeFilter : IFilter
    {
        public string Filter(string path)
        {
            using (var image = new MagickImage(path))
            {
                image.Solarize(new Percentage(50));
                return FilterProcess.GetResult(image);
            }
        }
    }
}