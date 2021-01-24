using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputSetsLenght = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            HashSet<int>firstSet = new HashSet<int>();
            HashSet<int>secondSet = new HashSet<int>();
            for (int i = 0; i < inputSetsLenght[0]+inputSetsLenght[1]; i++)
            {
                int inputElement = int.Parse(Console.ReadLine());
                if (i<inputSetsLenght[0])
                {
                    firstSet.Add(inputElement);
                }
                else
                {
                    secondSet.Add(inputElement);
                }
            }
            firstSet.IntersectWith(secondSet);
            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}