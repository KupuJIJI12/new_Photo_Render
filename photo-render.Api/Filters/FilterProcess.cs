using System.IO;
using ImageMagick;

namespace photo_render.Api.Filters
{
    /*дабы соблюсти принцип DRY, логика из метода Filter() была вынесена в этот класс
     в единственный метод ожидается получение уже отфильтрованного изображения
     затем создается файл в bin/Debug с генерируемым id и изображение записывается в этот файл
     после, файл отправляется в так называемое временное хранилище FilesList
     результат метода - uri нового обработанного изображения*/
    public static class FilterProcess
    {
        public static string GetResult(MagickImage image)
        {
            var fileInfo = new FileInfo($"{IdGenerator.GenerateId()}.png");
            image.Write(fileInfo);
            FileStorage.FilesList.Add(fileInfo);
            return image.FileName;
        }
    }
}