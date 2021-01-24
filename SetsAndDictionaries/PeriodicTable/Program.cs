using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string>uniqueElements = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                var inputLines = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                foreach (var currElement in inputLines)
                {
                    uniqueElements.Add(currElement);
                }
            }

            Console.WriteLine(string.Join(" ", uniqueElements));
        }
    }
}