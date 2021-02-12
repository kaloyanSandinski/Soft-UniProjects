using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputLiquids = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var inputIngredients = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> liquids = new Queue<int>(inputLiquids);
            Stack<int> ingredients = new Stack<int>(inputIngredients);
            Dictionary<string, int> cookedFoods = new Dictionary<string, int>()
            {
                {"Bread", 0},
                {"Cake", 0},
                {"Pastry", 0},
                {"Fruit Pie", 0}
                
            };
            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int result = liquids.Peek() + ingredients.Peek();
                if (result == 25)
                {
                    //Bread
                    cookedFoods["Bread"]++;

                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (result == 50)
                {
                    //Cake
                    cookedFoods["Cake"]++;

                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (result == 75)
                {
                    //Pastry
                    cookedFoods["Pastry"]++;

                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (result == 100)
                {
                    //Fruit Pie
                    cookedFoods["Fruit Pie"]++;

                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    ingredients.Push(ingredients.Pop() + 3);
                }
            }

            if (cookedFoods["Bread"] > 0 && cookedFoods["Cake"] > 0 && cookedFoods["Pastry"] > 0 &&
                cookedFoods["Fruit Pie"] > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            cookedFoods =cookedFoods.OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var currFood in cookedFoods)
            {
                Console.WriteLine($"{currFood.Key}: {currFood.Value}");
            }
        }
    }
}