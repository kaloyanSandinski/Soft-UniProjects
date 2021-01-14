using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputStr = Console.ReadLine();
            Stack<int> index = new Stack<int>();
            for (int i = 0; i < inputStr.Length; i++)
            {
                if (inputStr[i]=='(')
                {
                    index.Push(i);
                }
                else if (inputStr[i]==')')
                {
                    int startIndex = index.Pop();
                    Console.WriteLine(inputStr.Substring(startIndex, i-startIndex+1));
                }
            }
        }
    }
}