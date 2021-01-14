using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputN = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> numbers = new Stack<int>(inputN);
            string command = Console.ReadLine().ToLower();
            while (command != "end")
            {
                if (command.Contains("add"))
                {
                    string[] splitted = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    numbers.Push(int.Parse(splitted[1]));
                    numbers.Push(int.Parse(splitted[2]));
                }
                else
                {
                    string[] splitted = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    int numbersToRemove = int.Parse(splitted[1]);
                    if (numbers.Count >= numbersToRemove)
                    {
                        for (int i = 0; i < numbersToRemove; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }

                command = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: " + numbers.Sum());
        }
    }
}