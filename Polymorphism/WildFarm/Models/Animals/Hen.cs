using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm
{
    public class Hen : Bird
    {
        private const double weightMultyplyer = 0.35;
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override List<Type> AllowedFoods => new List<Type>()
            {typeof(Meat), typeof(Fruit), typeof(Seeds), typeof(Vegetable)};

        public override double WeightMultiplyer => weightMultyplyer;

        public override void AskForFood()
        {
            Console.WriteLine("Cluck");
        }
    }
}
