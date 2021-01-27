using System;
using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("data", "Input.txt");
            string dest = Path.Combine("data", "Output.txt");
            using (TextReader reader = new StreamReader(path))
            {
                using (TextWriter writer = new StreamWriter(dest))
                {
                    string currline = reader.ReadLine();
                    int counter = 1;
                    while (currline!=null)
                    {
                        writer.WriteLine($"{counter}. {currline}");
                        counter++;
                        currline = reader.ReadLine();
                    } 
                }
            }
        }
    }
}