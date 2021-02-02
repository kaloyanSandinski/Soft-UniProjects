using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var inputDeviders = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            Func<int, int, bool> predicate = (num, d) => { return num % d == 0; };
            for (int i = 1; i <= n; i++)
            {
                if (inputDeviders.All(d => predicate(i, d)))
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}