using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SecondProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Regex regex = new Regex(@"(!)(?<command>[A-Z][a-z]{2,})\1:\[(?<message>[A-z]{8,})\]");
            for (int i = 0; i < n; i++)
            {
                string inputCommands = Console.ReadLine();
                Match matches = regex.Match(inputCommands);
                if (matches.Success)
                {
                    List<int> encription = new List<int>();
                    string currMatch = matches.Groups["message"].Value;
                    string currCommand = matches.Groups["command"].Value;
                    foreach (var character in currMatch)
                    {
                        encription.Add((int) character);
                    }

                    Console.Write($"{currCommand}: ");
                    Console.WriteLine(string.Join(" ", encription));
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}