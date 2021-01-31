using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> myParse = s => int.Parse(s);
            var inoutNums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(myParse)
                .ToArray();
            Func<int[], int> MinFunc = nums =>
            {
                int min = int.MaxValue;
                foreach (var currNum in nums)
                {
                    if (currNum < min)
                    {
                        min = currNum;
                    }
                }

                return min;
            };
            Console.WriteLine(MinFunc(inoutNums));
        }
    }
}