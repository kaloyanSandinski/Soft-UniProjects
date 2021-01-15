using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stackClothes = new Stack<int>(clothes);
            int inputRackCapacity = int.Parse(Console.ReadLine());
            int rackCapacity = inputRackCapacity;
            int rackQuantity = 1;
            while (stackClothes.Any())
            {
                if (rackCapacity >=stackClothes.Peek())
                {
                    rackCapacity -= stackClothes.Pop();
                }
                else
                {
                    rackQuantity++;
                    rackCapacity = inputRackCapacity;
                }
            }

            Console.WriteLine(rackQuantity);
        }
    }
}