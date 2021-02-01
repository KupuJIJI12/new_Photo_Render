using Bmp = System.Drawing.Bitmap;

namespace photo_render.Api.Filters
{
    public interface IFilter
    {
        Bmp Filter();
    }
}