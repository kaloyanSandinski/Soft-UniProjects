using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> carsInJam = new Queue<string>();
            int n = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int counter = 0;
            while (command != "end")
            {
                if (command == "green")
                {
                    if (carsInJam.Count - n < 0)
                    {
                        n = carsInJam.Count;
                    }

                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine($"{carsInJam.Dequeue()} passed!");
                    }

                    counter += n;
                }
                else
                {
                    carsInJam.Enqueue(command);
                }

                command = Console.ReadLine();
            }
            
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}

