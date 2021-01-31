using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNums = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray();
            string command = Console.ReadLine();
            PassComands(inputNums,command);
            
        }

        public static void PassComands(int[] inputNums, string command)
        {
            int[] outputNums = inputNums.ToArray();
            while (command!="end")
            {
                if (command=="add")
                {
                    outputNums = MySelect(outputNums, x => x + 1);
                }
                else if (command=="multiply")
                {
                    outputNums = MySelect(outputNums, x => x * 2);
                }
                else if (command=="subtract")
                {
                    outputNums = MySelect(outputNums, x => x - 1);
                }
                else if (command=="print")
                {
                    Action<int[]> output = x =>
                    {
                        Console.WriteLine(string.Join(" ",x));
                    };
                    output(outputNums);
                }

                command = Console.ReadLine();
            }
        }

        public static int[] MySelect(int[] nums, Func<int, int> func)
        {
            List<int> output = new List<int>();
            foreach (var currNum in nums)
            {
                output.Add(func(currNum));
            }

            return output.ToArray();
        }
    }
}