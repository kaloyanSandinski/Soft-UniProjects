using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla: IElectricCar , ICar
    {
        public int Battery { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        public Tesla(string model, string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }
        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return $"{Color} {nameof(Tesla)} {Model} with {Battery} Batteries\n{Start()}\n{Stop()}";
        }
    }
}
