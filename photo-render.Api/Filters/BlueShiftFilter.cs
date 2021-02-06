using ImageMagick;

namespace photo_render.Api.Filters
{
    public class BlueShiftFilter : IFilter
    {
        public string Filter(string path)
        {
            using (var image = new MagickImage(path))
            {
                image.BlueShift(1);
                return FilterProcess.GetResult(image);
            }
        }
    }
}