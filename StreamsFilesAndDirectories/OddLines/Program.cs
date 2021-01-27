using System;
using System.IO;
using System.IO.Compression;

namespace OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("data", "Input.txt");
            string dest = Path.Combine("data", "Output.txt");
            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                using (TextReader text = new StreamReader(file))
                {
                    using (FileStream destFile = new FileStream(dest, FileMode.Create))
                    {
                        using (TextWriter writer = new StreamWriter(destFile))
                        {
                            string currLine = text.ReadLine();
                            int count = 0;
                            while (currLine != null)
                            {
                                if (count % 2 != 0)
                                {
                                    writer.WriteLine(currLine);
                                }

                                count++;
                                currLine = text.ReadLine();
                            }
                        }
                    }
                }
            }
        }
    }
}