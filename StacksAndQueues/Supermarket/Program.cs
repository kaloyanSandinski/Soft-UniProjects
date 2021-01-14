using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();
            string people = Console.ReadLine();
            while (people!="End")
            {
                if (people=="Paid")
                {
                    Console.WriteLine(String.Join(Environment.NewLine, customers));
                    customers.Clear();
                }
                else
                {
                    customers.Enqueue(people);
                }

                people = Console.ReadLine();
            }

            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}