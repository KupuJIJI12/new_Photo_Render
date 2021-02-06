using ImageMagick;

namespace photo_render.Api.Filters
{
    public class PosterizeFilter : IFilter
    {
        public string Filter(string path)
        {
            using (var image = new MagickImage(path))
            {
                image.Posterize(3);
                return FilterProcess.GetResult(image);
            }
        }
    }
}