using System.Runtime.CompilerServices;

namespace DefiningClasses
{
    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        //public string WhoAreThose()
        //{
        //    return $"{this.Name} {this.Age}";
        //}

        public string Name { get; set; }
        public int Age { get; set; }
    }
}