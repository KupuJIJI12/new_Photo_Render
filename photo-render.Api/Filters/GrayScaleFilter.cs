using photo_render.Api.Bitmap;

namespace photo_render.Api.Filters
{
    public class GrayScaleFilter : IFilter
    {
        private Pixel[,] Original { get; }

        public GrayScaleFilter(Pixel[,] original)
        {
            Original = original;
        }
        
        public System.Drawing.Bitmap Filter()
        {
            var width = Original.GetLength(0);
            var height = Original.GetLength(1);
            var grayscale = new double[width, height];
            
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                    grayscale[x, y] = GetShadeOfGray(Original[x, y]);
            }

            return grayscale.ToBitmap();
        }
        
        private static double GetShadeOfGray(Pixel pixel) => 
            (0.299 * pixel.Red + 0.587 * pixel.Green + 0.114 * pixel.Blue) / 255;
    }
}