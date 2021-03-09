using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        //You should model a class Pizza, which should have a name, dough and toppings as fields. Every type of ingredient should have its own class. 
        private string name;
        private Dough pizzaDough;
        private int toppingsCount = 0;
        private double totalCalories;

        public Pizza(string name)
        {
            Name = name;
        }
        //Pizza should have public getters for its name, number of toppings and the total calories. The total calories are calculated by summing the calories of all the ingredients a Pizza has. Create the class using a proper constructor, expose a method for adding a topping, a public setter for the dough and a getter for the total calories.
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (value.Length>15&& value.Length<1)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public Dough PizzaDough
        {
            get => pizzaDough;
            set
            {
                pizzaDough = value;
                totalCalories += value.Calories;
            }
        }

        public double TotalCalories
        {
            get => totalCalories;
            private set
            {
                totalCalories = value;
            }
        }

        private int ToppingsCount
        {
            get => toppingsCount;
        }

        public void AddingToppings(Topping topping)
        {
            toppingsCount++;
            if (ToppingsCount>10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            totalCalories += topping.Calories;
        }
    }
}
