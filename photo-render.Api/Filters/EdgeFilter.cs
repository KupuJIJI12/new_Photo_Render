using ImageMagick;

namespace photo_render.Api.Filters
{
    public class EdgeFilter : IFilter
    {
        public string Filter(string path)
        {
            using (var image = new MagickImage(path))
            {
                image.Edge(2);
                return FilterProcess.GetResult(image);
            }
        }
    }
}