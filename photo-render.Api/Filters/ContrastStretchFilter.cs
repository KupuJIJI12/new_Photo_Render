using ImageMagick;

namespace photo_render.Api.Filters
{
    public class ContrastStretchFilter : IFilter
    {
        public string Filter(string path)
        {
            using (var image = new MagickImage(path))
            {
                image.ContrastStretch(new Percentage(10));
                return FilterProcess.GetResult(image);
            }
        }
    }
}