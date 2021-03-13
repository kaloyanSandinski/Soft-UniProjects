using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<IIdentifiable> identifiables = new List<IIdentifiable>();
            while (command != "End")
            {
                var currComand = command.Split();
                if (currComand.Length == 2)
                {
                    Robot robot = new Robot(currComand[0], currComand[1]);
                    identifiables.Add(robot);
                }
                else
                {
                    Citizen citizen = new Citizen(currComand[0], int.Parse(currComand[1]), currComand[2]);
                    identifiables.Add(citizen);
                }

                command = Console.ReadLine();
            }

            string invalid = Console.ReadLine();

            List<IIdentifiable> filtred = identifiables
                .Where(x => x.Id.EndsWith(invalid))
                .ToList();

            foreach (var identifiable in filtred)
            {
                Console.WriteLine(identifiable.Id);
            }
        }
    }
}
