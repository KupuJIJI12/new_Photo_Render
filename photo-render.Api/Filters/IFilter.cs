using System.Drawing;
using Bmp = System.Drawing.Bitmap;

namespace photo_render.Api.Filters
{
    public interface IFilter
    {
        string Path { get; }

        string Filter();
        
    }
}