using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm
{
    public class Dog : Mammal
    {
        private const double weightMultyplyer = 0.40;
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override List<Type> AllowedFoods => new List<Type>() {typeof(Meat)};
        public override double WeightMultiplyer => weightMultyplyer;

        public override void AskForFood()
        {
            Console.WriteLine("Woof!");
        }

        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
