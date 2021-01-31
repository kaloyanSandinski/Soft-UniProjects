using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = GetPeople();
            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            Func<int, bool> tester = Checker(condition, age);
            Action<KeyValuePair<string, int>> printer = 
                Printer(format);
            InvokePrinter(people, tester, printer);
        }
        
        private static void InvokePrinter(
            Dictionary<string, int> people, 
            Func<int, bool> tester, 
            Action<KeyValuePair<string, int>> printer)
        {
            foreach (var person in people)
            {
                if (tester(person.Value))
                {
                    printer(person);
                }
            }
        }

        private static Action<KeyValuePair<string, int>> Printer(string format)
        {
            switch (format)
            {
                case "name age":
                    return kvp => Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                case "name":
                    return kvp => Console.WriteLine($"{kvp.Key}");
                case "age":
                    return kvp => Console.WriteLine($"{kvp.Value}");
                default:
                    return null;
            }
        }


        private static Func<int, bool> Checker(string olderOrYounger, int age)
        {
            switch (olderOrYounger)
            {
                case "older":
                    return n => n >= age;
                case "younger":
                    return n => n < age;
                default:
                    return null;
            }
        }

        private static Dictionary<string, int> GetPeople()
        {
            var numberOfLines = int.Parse(Console.ReadLine());
            var people = new Dictionary<string, int>(numberOfLines);

            for (int i = 0; i < numberOfLines; i++)
            {
                var input = Console.ReadLine()
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                people[input[0]] = int.Parse(input[1]);
            }

            return people;
        }
    }
}