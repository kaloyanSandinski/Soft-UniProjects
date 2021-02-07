using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                var inputData = Console.ReadLine().Split().ToArray();
                //string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age
                Car car = new Car(inputData[0], int.Parse(inputData[1]), int.Parse(inputData[2]),
                    int.Parse(inputData[3]), inputData[4], double.Parse(inputData[5]),
                    int.Parse(inputData[6]), double.Parse(inputData[7]), int.Parse(inputData[8]),
                    double.Parse(inputData[9]), int.Parse(inputData[10]), double.Parse(inputData[11]),
                    int.Parse(inputData[12]));
                cars.Add(car);
            }

            GetCars(Console.ReadLine(), cars);
        }

        public static void GetCars(string command, List<Car> cars)
        {
            if (command == "fragile")
            {
                foreach (var currCar in cars)
                {
                    if (currCar.Cargo.Type == "fragile" && currCar.Tire.Tire1Pressure < 1 ||
                        currCar.Tire.Tire2Pressure < 1 || currCar.Tire.Tire3Pressure < 1 ||
                        currCar.Tire.Tire4Pressure < 1)
                    {
                        Console.WriteLine(currCar.Model);
                    }
                }
            }
            else
            {
                foreach (var currCar in cars)
                {
                    if (currCar.Cargo.Type=="flamable"&&currCar.Engine.Power>250)
                    {
                        Console.WriteLine(currCar.Model);
                    }
                }
            }
        }
    }
}