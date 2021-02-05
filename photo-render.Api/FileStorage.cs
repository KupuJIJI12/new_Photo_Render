using System.Collections.Generic;
using System.IO;

namespace photo_render.Api
{
    /*Временное хранилище файлов, фиксированного размера (6 на данный момент)*/
    public static class FileStorage
    {
        public static LinkedList<FileInfo> FilesList { get; }

        static FileStorage()
        {
            FilesList =  new LinkedList<FileInfo>();
        }
        
        /*когда элементов больше 5 (т.е. 6), удаляется первый, и новый приходит в конец*/
        public static void Add(this LinkedList<FileInfo> list, FileInfo fileInfo)
        {
            if (list.Count > 5)
                list.Delete();
            list.AddLast(fileInfo);
        }

        /*удаление элемента из списка и bin/Debug*/
        public static void Delete(this LinkedList<FileInfo> list)
        {
            list.First.Value.Delete();
            list.RemoveFirst();
        }
        
        /*Удаление всех временных файлов, кроме последнего, т.к. он занят процессом приложения*/
        public static void RemoveUnusedTrash()
        {
            var temp = FilesList.First;
            if (temp is null) return;
            while (temp != FilesList.Last)
            {
                temp = temp.Next;
                FilesList.Delete();
            }                
        }
        
        /*Удаление всех временных файлов, которое запускается при закрытии приложения, но почему-то не работает
         Как итог, всегда остается один файл в bin/Debug, но это не страшно, в случае нового запуска проекта 
            он просто перезапишется в новый, не выдав исключений*/
        public static void RemoveTrash()
        {
            foreach (var fileInfo in FilesList)
                fileInfo.Delete();
            FilesList.Clear();
        }
    }
}