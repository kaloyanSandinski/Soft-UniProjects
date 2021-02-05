using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {

        public void AddMember(Person person)
        {
            allPersons.Add(person);
        }

        public void GetOldestMember()
        {
            int maxAge = int.MinValue;
            string nameMaxAge = String.Empty;
            foreach (var currPerson in allPersons)
            {
                if (maxAge<currPerson.Age)
                {
                    maxAge = currPerson.Age;
                    nameMaxAge = currPerson.Name;
                }
            }

            Console.WriteLine(nameMaxAge+" "+maxAge);
        }

        List<Person> allPersons = new List<Person>();
    }
}