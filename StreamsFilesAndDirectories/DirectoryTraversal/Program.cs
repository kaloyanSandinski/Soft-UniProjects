using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileNames = Directory.GetFiles(Console.ReadLine());
            Dictionary<string, Dictionary<string, double>> dataInfo =
                new Dictionary<string, Dictionary<string, double>>();
            foreach (var currFile in fileNames)
            {
                var fileInfo = new FileInfo(currFile);

                double fileSize = fileInfo.Length / 1024.0;
                string fileName = fileInfo.Name;
                string extension = fileInfo.Extension;
                if (!dataInfo.ContainsKey(extension))
                {
                    dataInfo.Add(extension, new Dictionary<string, double>());
                }

                dataInfo[extension].Add(fileName, fileSize);
            }

            dataInfo = dataInfo.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
           
            var reportDestination = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var resPath = Path.Combine(reportDestination, "report.txt");
                using (TextWriter writer = new StreamWriter(resPath))
                {
                    foreach (var curData in dataInfo)
                    {
                        writer.WriteLine($"{curData.Key}");
                        foreach (var curFile in curData.Value)
                        {
                            writer.WriteLine($"--{curFile.Key} - {curFile.Value:f3}kb");
                        }
                    }
                }
            
        }
    }
}