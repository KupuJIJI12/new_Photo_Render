using ImageMagick;

namespace photo_render.Api.Filters
{
    public class UnSharpFilter : IFilter
        {
            public string Filter(string path)
            {
                using (var image = new MagickImage(path))
                {
                    image.UnsharpMask(1, 3);
                    return FilterProcess.GetResult(image);
                }
            }
    }
}
