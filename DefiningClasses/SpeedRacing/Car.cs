using System;
using System.Runtime.CompilerServices;

namespace SpeedRacing
{
    public class Car
    {
        public Car()
        {
            TravelledDistance = 0;
        }
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer) : this()
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }
        
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive(double amountKm)
        {
            double consumption = amountKm * FuelConsumptionPerKilometer;
            if (FuelAmount-consumption>=0)
            {
                FuelAmount -= consumption;
                TravelledDistance += amountKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}