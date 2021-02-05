using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person[] personite = new Person[]
            {
                new Person("Ivan", 24),
                new Person("Petkan", 23),
                new Person("Pishman", 18),
            };
            //foreach (var currPerson in personite)
            //{
            //    Console.WriteLine(currPerson.WhoAreThose());
            //}
        }
    }
}