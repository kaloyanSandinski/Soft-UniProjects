using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputValues = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            Dictionary<double, int> countOfElements = new Dictionary<double, int>();
            for (int i = 0; i < inputValues.Length; i++)
            {
                if (countOfElements.ContainsKey(inputValues[i]))
                {
                    countOfElements[inputValues[i]]++;
                }
                else
                {
                    countOfElements.Add(inputValues[i], 1);
                }
            }

            foreach (var currValue in countOfElements)
            {
                Console.WriteLine($"{currValue.Key} - {currValue.Value} times");
            }
        }
    }
}