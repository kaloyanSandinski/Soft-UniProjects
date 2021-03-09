using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private int weight;
        private const int defCalorie = 2;
        private double calories;
        private string typeOfTopping;

        public Topping(string typeOfTopping, int weight)
        {
            TypeOfTopping = typeOfTopping;
            Weight = weight;
            Calories = CalloriesCalculator.ToppingCalculator(TypeOfTopping.ToLower(), Weight, defCalorie);
        }

        private int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value<1||value>50)
                {
                    throw new Exception($"{TypeOfTopping} weight should be in the range [1..50].");
                }

                weight = value;
            }
        }
        private string TypeOfTopping
        {
            get
            {
                return typeOfTopping;
            }
            set
            {
                if (value.ToLower()!="meat"&&value.ToLower()!="veggies"&&value.ToLower()!="cheese"&&value.ToLower()!="sauce")
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }

                typeOfTopping = value;
            }
        }

        public double Calories
        {
            get { return calories; }
            private set { calories = value; }
        }
    }
}
