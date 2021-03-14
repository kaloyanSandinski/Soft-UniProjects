using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<IBirthday> birthdays = new List<IBirthday>();
            while (command != "End")
            {
                var currComand = command.Split();
                if (currComand[0]==nameof(Citizen))
                {
                    IBirthday citizenBirthday = new Citizen(currComand[1], int.Parse(currComand[2]), currComand[3], currComand[4]);
                    birthdays.Add(citizenBirthday);
                }
                else if (currComand[0]==nameof(Pet))
                {
                    IBirthday petBirthday = new Pet(currComand[1], currComand[2]);
                    birthdays.Add(petBirthday);
                }

                command = Console.ReadLine();
            }

            string year = Console.ReadLine();

            List<IBirthday> filtred = birthdays
                .Where(x => x.Birthdate.EndsWith(year))
                .ToList();
            if (filtred.Count==0)
            {
                Console.WriteLine();
            }
            else
            {
                foreach (var identifiable in filtred)
                {
                    Console.WriteLine(identifiable.Birthdate);
                }
            }
        }
    }
}