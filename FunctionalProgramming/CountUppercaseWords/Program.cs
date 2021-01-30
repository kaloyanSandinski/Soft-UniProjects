using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> checker = x => x[0] == x.ToUpper()[0];
            var words = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Where(checker)
                .ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}