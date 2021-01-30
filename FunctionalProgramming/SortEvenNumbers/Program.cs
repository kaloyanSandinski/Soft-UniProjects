using System;
using System.Linq;

namespace SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .Where(n=>n%2==0)
                .OrderBy(n=>n)
                .ToArray();
            Console.WriteLine(string.Join(", ", nums));
        }
    }
}