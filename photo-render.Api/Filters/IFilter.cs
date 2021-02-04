using Bmp = System.Drawing.Bitmap;
using Image = System.Drawing.Image;

namespace photo_render.Api.Filters
{
    public interface IFilter
    {
        string Path { get; }

        Image Filter();
        
    }
}