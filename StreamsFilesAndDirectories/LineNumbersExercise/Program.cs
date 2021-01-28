using System;
using System.IO;

namespace LineNumbersExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine("data", "text.txt");
            var destination = Path.Combine("data", "output.txt");
            var lines = File.ReadAllLines(path);
            for (int i = 1; i <= lines.Length; i++)
            {
                int characters = 0;
                int symbols = 0;
                foreach (var character in lines[i - 1])
                {
                    if (character == '-' || character == '!' || character == ',' || character == '.' ||
                        character == '?' || character == '\'')
                    {
                        symbols++;
                    }
                    else if (character!=' ')
                    {
                        characters++;
                    }
                }

                lines[i - 1] = $"Line {i}: {lines[i - 1]} ({characters})({symbols})";
            }

            File.WriteAllLines(destination, lines);
        }
    }
}