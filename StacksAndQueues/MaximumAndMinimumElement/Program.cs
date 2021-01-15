using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stackedElements = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int[] queries = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int command = queries[0];
                if (command == 1)
                {
                    stackedElements.Push(queries[1]);
                }
                else if (command == 2)
                {
                    stackedElements.Pop();
                }
                else if (command == 3 && stackedElements.Any())
                {
                    Console.WriteLine(stackedElements.Max());
                }
                else if (command == 4 && stackedElements.Any())
                {
                    Console.WriteLine(stackedElements.Min());
                }
            }

            Console.WriteLine(String.Join(", ", stackedElements));
        }
    }
}