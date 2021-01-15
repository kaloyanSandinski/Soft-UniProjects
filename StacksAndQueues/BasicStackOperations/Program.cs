using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = inputData[0];
            int s = inputData[1];
            int x = inputData[2];
            int[] inputNums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> integerSt = new Stack<int>(inputNums);
            if (s > n)
            {
                s = n;
            }

            for (int i = 0; i < s; i++)
            {
                integerSt.Pop();
            }

            if (integerSt.Count > 0)
            {
                if (integerSt.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(integerSt.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}