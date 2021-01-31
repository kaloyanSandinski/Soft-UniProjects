using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int start = inputSize[0];
            int end = inputSize[1];
            string type = Console.ReadLine();
            
            Func<int, int, List<int>> generateNumbers = (start, end) =>
            {
                List<int> nums = new List<int>();

                for (int i = start; i <= end; i++)
                {
                    nums.Add(i);
                }

                return nums;
            };
            List<int> nums = generateNumbers(start, end);

            Predicate<int> getWantedNums = n => n % 2 == 0;
            if (type=="odd")
            {
                getWantedNums = n => n % 2 != 0;
            }

            nums = MyWhere(nums, getWantedNums);
            Console.WriteLine(string.Join(" ", nums));
        }

        public static List<int> MyWhere(List<int> nums, Predicate<int> predicate)
        {
            List<int>myNums = new List<int>();

            foreach (var currNum in nums)
            {
                if (predicate(currNum))
                {
                    myNums.Add(currNum);
                }
            }

            return myNums;
        }
    }
}