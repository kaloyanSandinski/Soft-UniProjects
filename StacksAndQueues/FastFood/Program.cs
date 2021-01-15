using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] inputOrders = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> ordersQuantity = new Queue<int>(inputOrders);
            Console.WriteLine(ordersQuantity.Max());
            while (ordersQuantity.Any() && foodQuantity >= ordersQuantity.Peek())
            {
                foodQuantity -= ordersQuantity.Peek();
                ordersQuantity.Dequeue();
            }

            if (ordersQuantity.Any())
            {
                Console.Write($"Orders left: ");
                Console.WriteLine(String.Join(" ", ordersQuantity));
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}