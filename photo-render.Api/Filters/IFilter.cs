using System.Drawing;
using Bmp = System.Drawing.Bitmap;
using Image = System.Windows.Controls.Image;

namespace photo_render.Api.Filters
{
    public interface IFilter
    {
        string Path { get; }

        System.Drawing.Image Filter();
        
    }
}