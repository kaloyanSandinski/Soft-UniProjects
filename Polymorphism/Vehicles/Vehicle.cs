using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double quantity, double consumption)
        {
            FuelQuantity = quantity;
            FuelConsumption = consumption;
        }

        public double FuelQuantity { get; protected set; }
        public double FuelConsumption { get; protected set; }

        public abstract void Drive(double distance);
        public abstract void Refuel(double liters);
    }
}