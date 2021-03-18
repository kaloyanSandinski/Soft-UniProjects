using System;

namespace EnterNumbers
{ 
    public class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            Methods.ReadNumber(start, end);
        }
    }
}
