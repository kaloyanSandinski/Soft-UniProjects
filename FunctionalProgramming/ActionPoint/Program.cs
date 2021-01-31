using System;
using System.Linq;
using System.Threading.Channels;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .ToArray();
            Action<string> printName = n => Console.WriteLine(n);
            foreach (var currName in input)
            {
                printName(currName);
            }
        }
    }
}