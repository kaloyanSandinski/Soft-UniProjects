using System;
using System.IO;
using System.Linq;

namespace MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstFile = Path.Combine("data", "FileOne.txt");
            var secondFile = Path.Combine("data", "FileTwo.txt");
            var outputFile = Path.Combine("data", "OutputFile.txt");
            var firstText = File.ReadAllLines(firstFile);
            var secondText = File.ReadAllLines(secondFile);
            using (TextWriter outFile = new StreamWriter(outputFile))
            {
                for (int i = 0; i < firstText.Length; i++)
                {
                    outFile.WriteLine(firstText[i]);
                    outFile.WriteLine(secondText[i]);
                }
            }
        }
    }
}