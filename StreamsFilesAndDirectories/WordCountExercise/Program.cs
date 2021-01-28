using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCountExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordPath = Path.Combine("data", "words.txt");
            string textPath = Path.Combine("data", "text.txt");
            string actualResult = Path.Combine("data", "actualResult.txt");
            string expectedResult = Path.Combine("data", "expectedResult.txt");
            var words = File.ReadAllLines(wordPath);
            var splitBy = new char[] {'.', '?', '!', '-', ' ',','};
            var allText = File.ReadAllText(textPath)
                .ToLower()
                .Split(splitBy, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Dictionary<string, int> result = new Dictionary<string, int>();

            using (TextWriter writer = new StreamWriter(actualResult))
            {
                foreach (var word in words)
                {
                    int counter = 0;
                    foreach (var textWord in allText)
                    {
                        if (textWord == word)
                        {
                            counter++;
                        }
                    }

                    result.Add(word, counter);
                    writer.WriteLine($"{word} - {counter}");
                }
            }

            result = result.OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            using (TextWriter writer = new StreamWriter(expectedResult))
            {
                foreach (var currWord in result)
                {
                    writer.WriteLine($"{currWord.Key} - {currWord.Value}");
                }
            }
        }
    }
}