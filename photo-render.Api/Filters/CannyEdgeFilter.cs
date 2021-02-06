using ImageMagick;

namespace photo_render.Api.Filters
{
    public class CannyEdgeFilter : IFilter
    {
        public string Filter(string path)
        {
            using (var image = new MagickImage(path))
            {
                image.CannyEdge(1.0, 3.0, new Percentage(4), new Percentage(4));
                return FilterProcess.GetResult(image);
            }
        }
    }
}