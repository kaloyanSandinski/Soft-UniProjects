using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        //: the dough can be white or wholegrain and in addition, it can be crispy, chewy or homemade.
        private const int constCalories = 2;
        private double calories;
        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
            Calories = CalloriesCalculator.DoughCalculator(FlourType.ToLower(), BakingTechnique.ToLower(), Weight, constCalories);
        }
        
        private string FlourType
        {
            get { return flourType; }
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new Exception("Invalid type of dough.");
                }

                flourType = value;
            }

        }
        private string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new Exception("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }
        private int Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }
        public double Calories
        {
            get { return calories; }
            private set { calories = value; }
        }
    }
}
