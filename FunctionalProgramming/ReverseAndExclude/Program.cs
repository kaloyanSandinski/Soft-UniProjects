using System;
using System.Linq;
using System.Collections.Generic;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());
            List<int> output = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .Where(x => x % num != 0)
                .Reverse()
                .ToList();
            Printer(output);
        }

        public static void Printer(List<int> output)
        {
            Console.WriteLine(string.Join(' ', output));
        }
    }
}