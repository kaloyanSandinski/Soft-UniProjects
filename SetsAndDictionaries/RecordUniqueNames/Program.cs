using System;
using System.Collections.Generic;

namespace RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNames = int.Parse(Console.ReadLine());
            HashSet<string> setOfUniqueNames = new HashSet<string>();
            for (int i = 0; i < inputNames; i++)
            {
                var currName = Console.ReadLine();
                setOfUniqueNames.Add(currName);
            }

            foreach (var currName in setOfUniqueNames)
            {
                Console.WriteLine(currName);
            }
        }
    }
}