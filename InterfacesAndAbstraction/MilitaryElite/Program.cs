using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite.Enum;
using MilitaryElite.Interfaces;
using MilitaryElite.Models;

namespace MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IPrivate> privates = new List<IPrivate>();
            while (input!= "End")
            {
                var tokens = input.Split().ToArray();
                string soldierType = tokens[0];
                int id = int.Parse(tokens[1]);
                string firstName = tokens[2];
                string lastName = tokens[3];
                IPrivate soldier = null;
                if (soldierType=="Spy")
                {
                    
                }
                else if (soldierType=="Commando")
                {
                    
                }
                else if (soldierType=="Engineer")
                {
                    decimal salary = decimal.Parse(tokens[4]);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    soldier = new LieutenantGeneral(id, firstName, lastName, salary);
                    privates.Add(soldier);
                }
                else if (soldierType == "Private")
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    soldier = new Private(id, firstName, lastName, salary);
                    privates.Add(soldier);
                }

                Console.WriteLine(soldier);
                input = Console.ReadLine();
            }
        }
    }
}
