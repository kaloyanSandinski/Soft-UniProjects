using System;
using System.Collections;
using System.Linq;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
         StackOfStrings stack = new StackOfStrings();
         Console.WriteLine(stack.IsEmpty());
         stack.AddRange(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList());
         foreach (var element in stack)
         {
             Console.WriteLine(element);
         }
        }
    }
}