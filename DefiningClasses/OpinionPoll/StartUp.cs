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
            List<Person> persons = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().ToArray();
                Person person = new Person(input[0], int.Parse(input[1]));
                persons.Add(person);
            }
            persons = persons.OrderBy(x=>x.Name).ToList();

            foreach (var currPerson in persons)
            {
                if (currPerson.Age>30)
                {
                    Console.WriteLine($"{currPerson.Name} - {currPerson.Age}");
                }
            }
        }
    }
}