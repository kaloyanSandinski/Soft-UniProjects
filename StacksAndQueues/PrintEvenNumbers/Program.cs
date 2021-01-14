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
            List<int> output = new List<int>();
            while (inputNumbers.Count>0)
            {
                int currNum = inputNumbers.Dequeue();
                if (currNum%2==0)
                {
                    output.Add(currNum);
                }
            }

            Console.WriteLine(String.Join(", ", output));
        }
    }
}