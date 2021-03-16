using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double quantity, double consumption, double tankCapacity)
        {
            if (quantity > tankCapacity)
            {
                TankCapacity = quantity;
                FuelQuantity = 0;
            }
            else
            {
                FuelQuantity = quantity;
                TankCapacity = tankCapacity;
            }
            BaseFuelConsumation = consumption;
        }

        public double FuelQuantity { get; protected set; }
        protected double BaseFuelConsumation { get; set; }
        public double AirConditioner { get; protected set; }
        public double TankCapacity { get; protected set; }

        public double FuelConsumption { get; protected set; }

        public abstract void Drive(double distance);
        public abstract void Refuel(double liters);

        public void TurnOnAirConditioner()
        {
            FuelConsumption = BaseFuelConsumation + AirConditioner;
        }

        public void TurnOffAirConditioner()
        {
            FuelConsumption = BaseFuelConsumation;
        }
    }
}