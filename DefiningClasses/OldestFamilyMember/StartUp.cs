using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                var token = Console.ReadLine().Split().ToArray();
                Person currPerson = new Person(token[0], int.Parse(token[1]));
                family.AddMember(currPerson);
            }

            family.GetOldestMember();
        }
    }
}