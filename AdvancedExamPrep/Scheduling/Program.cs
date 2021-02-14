using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray());
            Queue<int> threads = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());
            int taskToBeKilled = int.Parse(Console.ReadLine());
            int removedThread = 0;
            while (tasks.Contains(taskToBeKilled) && threads.Any())
            {
                int currThread = threads.Peek();
                int currTask = tasks.Peek();
                if (currThread >= currTask)
                {
                    if (currTask == taskToBeKilled)
                    {
                        removedThread = threads.Peek();
                        tasks.Pop();
                    }
                    else
                    {
                        threads.Dequeue();
                        tasks.Pop();
                    }
                }
                else
                {
                    if (currTask == taskToBeKilled)
                    {
                        tasks.Pop();
                        removedThread = threads.Peek();
                    }
                    else
                    {
                        threads.Dequeue();
                    }
                }
            }

            Console.WriteLine($"Thread with value {removedThread} killed task {taskToBeKilled}");
            Console.Write(string.Join(" ", threads));
        }
    }
}