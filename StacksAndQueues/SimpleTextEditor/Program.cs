using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            string currSrt = String.Empty;
            Stack<string> returnedOperations = new Stack<string>();
            returnedOperations.Push(currSrt);
            int numberOfOperations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (command[0] == "1")
                {
                    currSrt = returnedOperations.Peek()+command[1];
                    returnedOperations.Push(currSrt);
                }
                else if (command[0] == "2")
                {
                    int amountToRemove = int.Parse(command[1]);
                    currSrt = returnedOperations.Peek().Remove(0, amountToRemove);
                    returnedOperations.Push(currSrt);
                }
                else if (command[0] == "3")
                {
                    currSrt = returnedOperations.Peek();
                    int index = int.Parse(command[1]);
                    Console.WriteLine(currSrt[index-1]);
                }
                else
                {
                    returnedOperations.Pop();
                    currSrt += returnedOperations.Peek();
                }
            }
        }
    }
}