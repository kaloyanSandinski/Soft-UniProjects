using System;
using System.Linq;

namespace PredicateParty
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var inputNames = Console.ReadLine()
                .Split()
                .ToList();

            string command = Console.ReadLine();
            while (command != "Party!")
            {
                var tokens = command.Split().ToList();

                Predicate<string> predicate = GetPredicate(tokens[1], tokens[2]);

                switch (tokens[0])
                {
                    case "Remove":
                        inputNames.RemoveAll(predicate);
                        break;
                    case "Double":
                    {
                        var matches = inputNames.FindAll(predicate);
                        if (matches.Count > 0)
                        {
                            int index = inputNames.FindIndex(predicate);
                            inputNames.InsertRange(index, matches);
                        }

                        break;
                    }
                }

                command = Console.ReadLine();
            }

            if (inputNames.Count != 0)
            {
                Console.WriteLine(string.Join(", ", inputNames) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string type, string argument)
        {
            switch (type)
            {
                case "StartsWith":
                    return (name) => name.StartsWith(argument);
                case "EndsWith":
                    return (name) => name.EndsWith(argument);
                case "Length":
                    return (name) => name.Length == int.Parse(argument);
                default:
                    throw new ArgumentException("Invalid command type: " + type);
            }
        }
    }
}