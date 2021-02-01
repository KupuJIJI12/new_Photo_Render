using System.Drawing;

namespace photo_render.Api
{
    public class Pixel
    {
        public Pixel(Color color)
        {
            Red = color.R;
            Blue = color.B;
            Green = color.G;
        }
        
        private float _red;
        public float Red
        {
            get => _red;
            set => _red = GetCorrectValue(value);
        } 
        
        private float _blue;
        public float Blue
        {
            get => _blue;
            set => _blue = GetCorrectValue(value);
        } 
        
        private float _green;
        public float Green
        {
            get => _green;
            set => _green = GetCorrectValue(value);
        } 
        
        private static float GetCorrectValue(float color)
        {
            if (color < 0.0) return 0.0f;
            if (color > 255.0) return 255.0f;
            return color;
        }
    }
}