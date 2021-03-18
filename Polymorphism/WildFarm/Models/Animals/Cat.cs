using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm
{
    public class Cat: Feline
    {
        private const double weightMultyplyer = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override List<Type> AllowedFoods => new List<Type>() {typeof(Meat), typeof(Vegetable)};
        public override double WeightMultiplyer => weightMultyplyer;

        public override void AskForFood()
        {
            Console.WriteLine("Meow");
        }
    }
}
