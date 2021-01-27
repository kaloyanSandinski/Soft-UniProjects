using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordsPath = Path.Combine("data", "words.txt");
            string inputPath = Path.Combine("data", "text.txt");
            string[] token = File.ReadAllText(wordsPath)
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var elementsToSplit = new char[] {'.', ' ', '?', '!', '-',','};
            var text = File.ReadAllText(inputPath)
                .ToLower()
                .Split(elementsToSplit, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            
            foreach (var currWord in token)
            {
                int counter = 0;
                foreach (var word in text)
                {
                    if (word==currWord)
                    {
                        counter++;
                    }
                }
                wordsCount.Add(currWord,counter);
            }

            foreach (var words in wordsCount)
            {
                Console.WriteLine($"{words.Key} - {words.Value}");
            }
        }
    }
}