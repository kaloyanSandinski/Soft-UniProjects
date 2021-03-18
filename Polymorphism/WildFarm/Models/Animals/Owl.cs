using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm
{
    public class Owl: Bird
    {
        private const double weightMultyplyer = 0.25;
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override List<Type> AllowedFoods => new List<Type>() {typeof(Meat)};
        public override double WeightMultiplyer => weightMultyplyer;

        public override void AskForFood()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
