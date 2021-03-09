using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var pizzaName = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var doughInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            try
            {
                Pizza pizza = new Pizza(pizzaName[1]);
                Dough dough = new Dough(doughInput[1], doughInput[2], int.Parse(doughInput[3]));
                pizza.PizzaDough = dough;
                string toppingInput = Console.ReadLine();
                while (toppingInput != "END")
                {
                    var currTopping = toppingInput.Split().ToArray();
                    Topping topping = new Topping(currTopping[1], int.Parse(currTopping[2]));
                    pizza.AddingToppings(topping);

                    toppingInput = Console.ReadLine(); 
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
