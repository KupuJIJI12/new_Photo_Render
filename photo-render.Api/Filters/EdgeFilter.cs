using ImageMagick;

namespace photo_render.Api.Filters
{
    public class EdgeFilter : IFilter
    {
        public string Path { get; }

        public EdgeFilter(string path)
        {
            Path = path;
        }


        public string Filter()
        {
            using (var image = new MagickImage(Path))
            {
                image.Edge(2);
                image.Write("~pic.png");
                return image.FileName;
            }
        }
    }
}