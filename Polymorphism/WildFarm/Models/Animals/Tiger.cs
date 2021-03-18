using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm
{
    public class Tiger : Feline
    {
        private const double weightMultyplyer = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override List<Type> AllowedFoods => new List<Type>() {typeof(Meat)};
        public override double WeightMultiplyer => weightMultyplyer;

        public override void AskForFood()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}
