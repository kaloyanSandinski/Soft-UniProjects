using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double quantity, double consumption) 
            : base(quantity, consumption)
        {
            FuelConsumption = 0.9 + consumption;
        }

        public override void Drive(double distance)
        {
            if (FuelQuantity< distance*FuelConsumption)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }

            FuelQuantity -= distance * FuelConsumption;
            Console.WriteLine($"{GetType().Name} travelled {distance} km");
        }

        public override void Refuel(double liters)
        {
            FuelQuantity += liters;
        }
    }
}
