﻿using ImageMagick;

namespace photo_render.Api.Filters
{
    public class ShadeFilter : IFilter
    {
        private readonly string _path;

        public ShadeFilter(string path)
        {
            _path = path;
        }
        public string Filter()
        {
            using (var image = new MagickImage(_path))
            {
                image.Shade();
                
                image.Write("~\\Images");
                return image.FileName;
            }
        }
    }
}