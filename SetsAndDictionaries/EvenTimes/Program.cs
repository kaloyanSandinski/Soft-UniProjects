using System;
using System.Collections.Generic;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> allNumbers = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int currInput = int.Parse(Console.ReadLine());
                if (allNumbers.ContainsKey(currInput))
                {
                    allNumbers[currInput]++;
                }
                else
                {
                    allNumbers.Add(currInput, 1);
                }
            }

            foreach (var currNum in allNumbers)
            {
                if (currNum.Value%2==0)
                {
                    Console.WriteLine(currNum.Key);
                }
            }
        }
    }
}