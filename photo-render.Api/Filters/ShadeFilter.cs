using System.IO;
using ImageMagick;
using Image = System.Drawing.Image;

namespace photo_render.Api.Filters
{
    public class ShadeFilter : IFilter
    {
        public string Path { get; }
        
        public ShadeFilter(string path)
        {
            Path = path;
        }

        public Image Filter()
        {
            using (var image = new MagickImage(Path))
            {
                image.Shade();;
                var memoryStream = new MemoryStream(image.ToByteArray());
                return Image.FromStream(memoryStream);
            }
        }
    }
}