using System;
using System.Collections.Generic;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> kids =
                new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            int passes = int.Parse(Console.ReadLine());
            while (kids.Count > 1)
            {
                for (int i = 0; i < passes; i++)
                {
                    if (i == passes - 1)
                    {
                        Console.WriteLine($"Removed {kids.Dequeue()}");
                    }
                    else
                    {
                        kids.Enqueue(kids.Dequeue());
                    }
                }
            }

            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}