using System;
using System.Linq;
using Microsoft.VisualBasic;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Array.Sort(inputNums, (a, b) =>
            {
                if (a % 2 != 0 && b % 2 == 0)
                {
                    return 1;
                }
                else if (a % 2 == 0 && b % 2 != 0)
                {
                    return -1;
                }

                int temp = a.CompareTo(b);
                return temp;
            });
            Console.WriteLine(string.Join(" ", inputNums));
        }
    }
}