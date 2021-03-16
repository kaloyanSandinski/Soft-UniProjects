using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public static class FuelValidator
    {
        public static void Validator(double liters)
        {
            if (liters<=0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
        }
    }
}
