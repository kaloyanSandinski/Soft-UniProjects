using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            //goal to make at least 5 wreaths
            //stack Lilies
            //queue Roses
            Stack<int> lilies = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Queue<int> roses = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            int wreath = 0;
            int storedWreath = 0;
            while (lilies.Any() && roses.Any())
            {
                if (lilies.Peek() + roses.Peek() == 15)
                {
                    lilies.Pop();
                    roses.Dequeue();
                    wreath++;
                }
                else if (lilies.Peek() + roses.Peek() > 15)
                {
                    while (lilies.Peek() + roses.Peek() > 15)
                    {
                        lilies.Push(lilies.Pop() - 2);
                    }

                    if (lilies.Peek() + roses.Peek() == 15)
                    {
                        lilies.Pop();
                        roses.Dequeue();
                        wreath++;
                    }
                    else
                    {
                        storedWreath += lilies.Pop() + roses.Dequeue();
                    }
                }
                else
                {
                    storedWreath += lilies.Pop() + roses.Dequeue();
                }
            }

            if (storedWreath >= 15)
            {
                wreath += storedWreath / 15;
            }

            if (wreath >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreath} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5-wreath} wreaths more!");
            }
        }
    }
}