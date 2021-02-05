using System;
using System.Windows.Media.Imaging;
using photo_render.Api.Filters;

namespace photo_render.Api
{
    /*синглтон, экземпляр которого создается при инициализации окна приложения*/
    public class PhotoRender
    {
        private PhotoRender() { }
        private static PhotoRender _instance;

        public static PhotoRender GetInstance() => _instance ??= new PhotoRender();

        /* основной метод, который возвращает новое изображение
         в него передается любой фильтр, реализующий интерфейс, и пусть к изображению*/
        public BitmapSource Render(IFilter filter, string path) 
        {
            return new BitmapImage(new Uri(filter.Filter(path)));
        }
    }
}