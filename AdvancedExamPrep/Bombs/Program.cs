using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            //You need to start from the first bomb effect and try to mix it with the last bomb casing
            Queue<int> effect = new Queue<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray());
            Stack<int> casing = new Stack<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray());
            /*
             
             If the sum of their values is equal to any of the materials in the table below – create the bomb corresponding to the value and remove the both bomb materials. Otherwise, just decrease the value of the bomb casing by 5. You need to stop combining when you have no more bomb effects or bomb casings, or you successfully filled the bomb pouch.
             
            Datura Bombs: 40
            Cherry Bombs: 60
            Smoke Decoy Bombs: 120
            
             */
            Dictionary<string, int> bombs = new Dictionary<string, int>()
            {
                {"Datura Bombs", 0},
                {"Cherry Bombs", 0},
                {"Smoke Decoy Bombs", 0},
            };
            while (effect.Any() && casing.Any())
            {
                int number = effect.Peek() + casing.Peek();
                if (number == 40)
                {
                    bombs["Datura Bombs"]++;
                    effect.Dequeue();
                    casing.Pop();
                }
                else if (number == 60)
                {
                    bombs["Cherry Bombs"]++;
                    effect.Dequeue();
                    casing.Pop();
                }
                else if (number == 120)
                {
                    bombs["Smoke Decoy Bombs"]++;
                    effect.Dequeue();
                    casing.Pop();
                }
                else
                {
                    casing.Push(casing.Pop() - 5);
                }

                if (bombs["Datura Bombs"] >= 3 && bombs["Cherry Bombs"] >= 3 &&
                    bombs["Smoke Decoy Bombs"] >= 3)
                {
                    break;
                }
            }

            if (bombs["Datura Bombs"] >= 3 && bombs["Cherry Bombs"] >= 3 && bombs["Smoke Decoy Bombs"] >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effect.Any())
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", effect)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (casing.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casing)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            bombs = bombs
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var currBomb in bombs)
            {
                Console.WriteLine($"{currBomb.Key}: {currBomb.Value}");
            }
        }
    }
}