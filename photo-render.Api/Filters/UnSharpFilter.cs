using System.IO;
using ImageMagick;
using Image = System.Drawing.Image;

namespace photo_render.Api.Filters
{
    public class UnSharpFilter : IFilter
        {
            public string Path { get; }

            public UnSharpFilter(string path)
            {
                Path = path;
            }

            public Image Filter()
            {
                using (var image = new MagickImage(Path))
                {
                    image.UnsharpMask(1, 3);
                    ;
                    var memoryStream = new MemoryStream(image.ToByteArray());
                    return Image.FromStream(memoryStream);
                }
            }
    }
}
