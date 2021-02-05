using System;
using System.Linq;

namespace DateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstDate = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            DateModifier firstDateModifier = new DateModifier(firstDate[0],firstDate[1],firstDate[2]);
            var secondDate = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            DateModifier secondDateModifier = new DateModifier(secondDate[0],secondDate[1],secondDate[2]);
            secondDateModifier.GetAllDays(firstDateModifier, secondDateModifier);
        }
    }
}