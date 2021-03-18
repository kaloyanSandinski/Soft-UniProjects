using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        private const double weightMultyplyer = 0.10;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override List<Type> AllowedFoods => new List<Type>() {typeof(Vegetable), typeof(Fruit)};
        public override double WeightMultiplyer => weightMultyplyer;
        public override void AskForFood()
        {
            Console.WriteLine("Squeak");
        }

        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
