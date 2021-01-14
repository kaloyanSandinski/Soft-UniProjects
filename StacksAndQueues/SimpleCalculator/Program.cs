using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> expression =
                new Stack<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse());
            while (expression.Count > 1)
            {
                int num1 = int.Parse(expression.Pop());
                string symbol = expression.Pop();
                int num2 = int.Parse(expression.Pop());
                if (symbol == "+")
                {
                    expression.Push((num1 + num2).ToString());
                }
                else
                {
                    expression.Push((num1 - num2).ToString());
                }
            }

            Console.WriteLine(expression.Pop());
        }
    }
}