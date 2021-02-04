using System.IO;
using ImageMagick;
using Image = System.Drawing.Image;

namespace photo_render.Api.Filters
{
    public class EdgeFilter : IFilter
    {
        public string Path { get; }

        public EdgeFilter(string path)
        {
            Path = path;
        }


        public Image Filter()
        {
            using (var image = new MagickImage(Path))
            {
                image.Edge(2);
                var memoryStream = new MemoryStream(image.ToByteArray());
                return Image.FromStream(memoryStream);
            }
        }
    }
}