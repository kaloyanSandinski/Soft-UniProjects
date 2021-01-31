using System;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNames = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Action<string> print = n => Console.WriteLine($"Sir {n}");
            foreach (var currName in inputNames)
            {
                print(currName);
            }
        }
    }
}