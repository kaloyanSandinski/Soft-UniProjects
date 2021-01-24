using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wordrobe = new Dictionary<string, Dictionary<string, int>>();
            var symbolsToSplit = new string[] {" -> ", ","};
            for (int i = 0; i < n; i++)
            {
                var inputData = Console.ReadLine()
                    .Split(symbolsToSplit, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int j = 0; j < inputData.Length; j++)
                {
                    if (j == 0)
                    {
                        if (!wordrobe.ContainsKey(inputData[0]))
                        {
                            wordrobe.Add(inputData[0], new Dictionary<string, int>());
                        }
                    }
                    else
                    {
                        if (wordrobe[inputData[0]].ContainsKey(inputData[j]))
                        {
                            wordrobe[inputData[0]][inputData[j]]++;
                        }
                        else
                        {
                            wordrobe[inputData[0]].Add(inputData[j], 1);
                        }
                    }
                }
            }

            var dress = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            foreach (var currColor in wordrobe)
            {
                Console.WriteLine($"{currColor.Key} clothes:");
                foreach (var currDress in currColor.Value)
                {
                    if (currColor.Key == dress[0] && currDress.Key == dress[1])
                    {
                        Console.WriteLine($"* {currDress.Key} - {currDress.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {currDress.Key} - {currDress.Value}");
                    }
                }
            }
        }
    }
}