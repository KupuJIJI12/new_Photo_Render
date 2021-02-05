using System.IO;
using ImageMagick;

namespace photo_render.Api.Filters
{
    public static class FilterProcess
    {
        public static string GetResult(MagickImage image)
        {
            var fileInfo = new FileInfo($"{IdGenerator.GenetateId()}.png");
            image.Write(fileInfo);
            FileStorage.FilesList.Add(fileInfo);
            return image.FileName;
        }
    }
}