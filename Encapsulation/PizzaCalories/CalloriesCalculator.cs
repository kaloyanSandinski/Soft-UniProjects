using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public static class CalloriesCalculator
    {
        public static double DoughCalculator(string flourType, string bakingTechnique,int weight, int calories)
        {
            double flourTypeCal = 0;
            if (flourType=="white")
            {
                flourTypeCal = 1.5;

            }
            else if (flourType == "wholegrain")
            {
                flourTypeCal = 1;
            }

            double bakingTechniqueCal = 0;
            if (bakingTechnique == "crispy")
            {
                   bakingTechniqueCal = 0.9;
            }

            else if (bakingTechnique == "chewy")
            {
                bakingTechniqueCal = 1.1;
            }
            else if (bakingTechnique == "homemade")
            {
                bakingTechniqueCal = 1;
            }

            return (weight * calories) * flourTypeCal * bakingTechniqueCal;
        }

        public static double ToppingCalculator(string toppingType, int weight, int deffCalories)
        {
            double calorieForTopping = 0;
            if (toppingType == "meat")
            {
                calorieForTopping = 1.2;
            }
            else if (toppingType=="veggies")
            {
                calorieForTopping = 0.8;
            }
            else if (toppingType =="cheese")
            {
                calorieForTopping = 1.1;
            }
            else if (toppingType=="sauce")
            {
                calorieForTopping = 0.9;
            }

            return (weight * deffCalories) * calorieForTopping;
        }
    }
}
