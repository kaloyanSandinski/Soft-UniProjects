using System;
using System.Linq;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            var carInput = Console.ReadLine().Split().ToArray();
            var trcukInput = Console.ReadLine().Split().ToArray();
            var busInput = Console.ReadLine().Split().ToArray();
            Vehicle car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]), double.Parse(carInput[3]));
            Vehicle truck = new Truck(double.Parse(trcukInput[1]), double.Parse(trcukInput[2]), double.Parse(trcukInput[3]));
            Vehicle bus = new Bus(double.Parse(busInput[1]), double.Parse(busInput[2]), double.Parse(busInput[3]));
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var commands = Console.ReadLine().Split();
                try
                {
                    if (commands[0] == "Drive")
                    {
                        if (commands[1] == "Car")
                        {
                            car.Drive(double.Parse(commands[2]));
                        }
                        else if (commands[1] == "Bus")
                        {
                            bus.TurnOnAirConditioner();
                            bus.Drive(double.Parse(commands[2]));
                        }
                        else
                        {
                            truck.Drive(double.Parse(commands[2]));
                        }
                    }
                    else if (commands[0] == "DriveEmpty")
                    {
                        bus.TurnOffAirConditioner();
                        bus.Drive(double.Parse(commands[2]));
                    }
                    else
                    {
                        if (commands[1] == "Car")
                        {
                            car.Refuel(double.Parse(commands[2]));
                        }
                        else if (commands[1] == "Bus")
                        {
                            bus.Refuel(double.Parse(commands[2]));
                        }
                        else
                        {
                            truck.Refuel(double.Parse(commands[2]));
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
