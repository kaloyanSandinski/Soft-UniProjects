using System;
using System.IO;
using System.Linq;

namespace EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("data", "text.txt");
            using (TextReader text = new StreamReader(path))
            {
                string currLine = text.ReadLine();
                int counter = 0;
                while (currLine != null)
                {
                    if (counter % 2 == 0)
                    {
                        currLine = currLine.Replace("-", "@")
                            .Replace(",", "@").Replace("?", "@")
                            .Replace(".", "@").Replace("!", "@");
                        var output = currLine.Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
                        Console.WriteLine(string.Join(" ", output));
                    }

                    counter++;
                    currLine = text.ReadLine();
                }
            }
        }
    }
}