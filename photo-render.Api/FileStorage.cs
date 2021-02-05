using System.Collections.Generic;
using System.IO;

namespace photo_render.Api
{
    public static class FileStorage
    {
        public static LinkedList<FileInfo> FilesList { get; }

        static FileStorage()
        {
            FilesList =  new LinkedList<FileInfo>();
        }

        public static void Add(this LinkedList<FileInfo> list, FileInfo fileInfo)
        {
            if (list.Count > 5)
                list.Delete();
            list.AddLast(fileInfo);
        }

        public static void Delete(this LinkedList<FileInfo> list)
        {
            list.First.Value.Delete();
            list.RemoveFirst();
        }
        
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
        
        public static void RemoveTrash()
        {
            foreach (var fileInfo in FilesList)
                fileInfo.Delete();
            FilesList.Clear();
        }
    }
}