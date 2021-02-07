using System;
using System.Collections.Generic;

namespace RawData
{
    public class Car
    {
        public Car(string model, int engineSpeed, int enginePower, int cargoWeight,
            string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure,
            int tire2Age, double tire3Pressure, int tire3Age, double tire4Pressure,
            int tire4Age)
        {
            Model = model;
            Engine = new Engine(enginePower, engineSpeed);
            Cargo = new Cargo(cargoWeight, cargoType);
            Tire = new Tire(tire1Age, tire1Pressure, tire2Age,
                tire2Pressure, tire3Age, tire3Pressure,
                tire4Age, tire4Pressure);
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire Tire { get; set; }
    }
}