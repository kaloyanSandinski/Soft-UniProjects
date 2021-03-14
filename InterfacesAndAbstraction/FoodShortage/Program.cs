using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<IPerson> persons = new List<IPerson>();
            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split();
                if (command.Length==4)
                {
                    persons.Add(new Citizen(command[0], int.Parse(command[1]), command[2], command[3]));
                }
                else
                {
                    persons.Add(new Rebel(command[0], int.Parse(command[1]), command[2]));
                }
            }

            string names = Console.ReadLine();
            int amountOfFood = 0;
            while (names!="End")
            {
                foreach (var person in persons)
                {
                    if (person.Name==names)
                    {
                        person.BuyFood();
                    }
                }

                names = Console.ReadLine();
            }

            foreach (var person in persons)
            {
                amountOfFood+=person.Food;
            }
            Console.WriteLine(amountOfFood);
        }
    }
}
