using System.Windows.Controls;

namespace photo_render.Api.Bitmap
{
    public class Converter
    {
        private Converter() { }
        private Converter(Image image) { Image = image; }
        private static Converter _instance;

        private Image Image { get; } 
        
        public static Converter Get(Image image) => _instance ??= new Converter(image);
    }
}