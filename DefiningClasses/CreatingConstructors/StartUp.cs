using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person tisho = new Person();
            Person misho = new Person(11);
            Person gosho = new Person("gosho", 23);
        }
    }
}