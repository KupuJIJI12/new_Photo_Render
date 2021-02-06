using ImageMagick;

namespace photo_render.Api.Filters
{
    public class WaveletDenoiseFilter : IFilter
    {
        public string Filter(string path)
        {
            using (var image = new MagickImage(path))
            {
                image.WaveletDenoise(new Percentage(95), 15);
                return FilterProcess.GetResult(image);
            }
        }
    }
}