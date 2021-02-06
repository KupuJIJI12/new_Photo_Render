using ImageMagick;

namespace photo_render.Api.Filters
{
    public class OilPaintFilter : IFilter
    {
        public string Filter(string path)
        {
            using (var image = new MagickImage(path))
            {
                image.OilPaint(1.5, 2.2);
                return FilterProcess.GetResult(image);
            }
        }
    }
}