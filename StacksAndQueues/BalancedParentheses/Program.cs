using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] inputData = Console.ReadLine().ToCharArray();
            Stack<char> sequenceOfBrackets = new Stack<char>(inputData);
            int length = sequenceOfBrackets.Count;
            bool isBalanced = true;
            if (length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }
            for (int i = 0; i < length; i++)
            {
                if (inputData[i] == '{' || inputData[i] == '[' || inputData[i] == '(')
                {
                    sequenceOfBrackets.Push(inputData[i]);
                }
                else
                {
                    if (sequenceOfBrackets.Peek() == '{' && inputData[i] != '}' ||
                        sequenceOfBrackets.Peek() == '[' && inputData[i] != ']' ||
                        sequenceOfBrackets.Peek() == '(' && inputData[i] != ')')
                    {
                        isBalanced = false;
                        break;
                    }
                    
                    sequenceOfBrackets.Pop();
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}