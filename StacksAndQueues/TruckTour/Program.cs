using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> firstCompletedCircle = new Queue<string>();
            for (int i = 0; i < n; i++)
            {
                firstCompletedCircle.Enqueue(Console.ReadLine());
            }

            int lenght = firstCompletedCircle.Count;
            int index = 0;
            for (int i = 0; i < lenght; i++)
            {
                bool isFullCircle = true;
                int tankCapacity = 0;
                for (int j = 0; j < lenght; j++)
                {
                    string currData = firstCompletedCircle.Dequeue();
                    firstCompletedCircle.Enqueue(currData);
                    if (isFullCircle)
                    {
                        string[] currStation = currData.Split().ToArray();
                        tankCapacity += int.Parse(currStation[0]);
                        int currDistance = int.Parse(currStation[1]);

                        if (tankCapacity - currDistance < 0)
                        {
                            isFullCircle = false;
                        }
                        else
                        {
                            tankCapacity -= currDistance;
                        }
                    }
                }

                if (isFullCircle)
                {
                    index = i;
                    break;
                }

                firstCompletedCircle.Enqueue(firstCompletedCircle.Dequeue());
            }

            Console.WriteLine(index);
        }
    }
}