using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using WildFarm.Foods;

namespace WildFarm
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; protected set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }
        public  abstract List<Type> AllowedFoods { get; }

        public abstract double WeightMultiplyer { get; }

        public abstract void AskForFood();

        public void Eat(Food food)
        {
            if (!AllowedFoods.Contains(food.GetType()))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            Weight += food.Quantity * WeightMultiplyer;

            FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, ";
        }
    }
}
