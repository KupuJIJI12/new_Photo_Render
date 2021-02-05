using ImageMagick;

namespace photo_render.Api.Filters
{
    public class UnSharpFilter : IFilter
        {
            public string Path { get; }

            public UnSharpFilter(string path)
            {
                Path = path;
            }

            public string Filter()
            {
                using (var image = new MagickImage(Path))
                {
                    image.UnsharpMask(1, 3);
                    return FilterProcess.GetResult(image);
                }
            }
    }
}
