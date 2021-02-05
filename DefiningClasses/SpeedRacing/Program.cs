using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                var inputCars = Console.ReadLine()
                    .Split()
                    .ToArray();
                Car currCar = new Car(inputCars[0], double.Parse(inputCars[1]), double.Parse(inputCars[2]));
                cars.Add(currCar);
            }

            string token = Console.ReadLine();
            while (token!="End")
            {
                var inputCommands = token.Split().ToArray();
                string carModel = inputCommands[1];
                double amountOfKm = double.Parse(inputCommands[2]);
                foreach (var currCar in cars)
                {
                    if (currCar.Model==carModel)
                    {
                        currCar.Drive(amountOfKm);
                    }
                }

                token = Console.ReadLine();
            }

            foreach (var currCar in cars)
            {
                Console.WriteLine($"{currCar.Model} {currCar.FuelAmount:f2} {currCar.TravelledDistance}");
            }
        }
    }
}