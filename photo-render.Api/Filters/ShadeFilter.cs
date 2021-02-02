using ImageMagick;

namespace photo_render.Api.Filters
{
    public class ShadeFilter : IFilter
    {
        public string Path { get; }
        
        public ShadeFilter(string path)
        {
            Path = path;
        }

        public string Filter()
        {
            using (var image = new MagickImage(Path))
            {
                image.Shade();
                image.Write("~pic.png");
                return image.FileName;
            }
        }
    }
}