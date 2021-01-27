using System;
using System.IO;

namespace FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryName = Console.ReadLine();
            string[] files =
                Directory.GetFiles(directoryName);
            double size = 0;
            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);
                size += info.Length;
            }

            Console.WriteLine(size/1024/1024);
        }
    }
}