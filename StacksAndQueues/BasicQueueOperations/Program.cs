using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = inputData[0];
            int s = inputData[1];
            int x = inputData[2];
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> inputNums = new Queue<int>(nums);
            if (s>n)
            {
                s = n;
            }

            for (int i = 0; i < s; i++)
            {
                inputNums.Dequeue();
            }

            if (inputNums.Any())
            {
                if (inputNums.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(inputNums.Min());
                }
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}