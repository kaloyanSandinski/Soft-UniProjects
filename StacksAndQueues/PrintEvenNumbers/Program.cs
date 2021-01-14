using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> inputNumbers =
                new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int count = inputNumbers.Count;
            for (int i = 0; i < count; i++)
            {
                if (inputNumbers.Peek()%2==0)
                {
                    inputNumbers.Enqueue(inputNumbers.Peek());
                }

                inputNumbers.Dequeue();
            }

            Console.WriteLine(String.Join(", ", inputNumbers));
        }
    }
}