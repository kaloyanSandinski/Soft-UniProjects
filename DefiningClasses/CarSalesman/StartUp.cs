using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < n; i++)
            {
                var inputEngines = Console.ReadLine().Split().ToArray();
                if (inputEngines.Length == 2)
                {
                    Engine currEngine = new Engine(inputEngines[0], int.Parse(inputEngines[1]));
                    engines.Add(currEngine);
                }
                else if (inputEngines.Length == 3)
                {
                    int displacement = 0;
                    if (Int32.TryParse(inputEngines[2],out displacement))
                    {
                        Engine currEngine = new Engine(inputEngines[0], int.Parse(inputEngines[1]),
                            displacement);
                        engines.Add(currEngine);
                    }
                    else
                    {
                        
                        Engine currEngine = new Engine(inputEngines[0], int.Parse(inputEngines[1]),
                            inputEngines[2]);
                        engines.Add(currEngine);
                    }
                }
                else
                {
                    Engine currEngine = new Engine(inputEngines[0], int.Parse(inputEngines[1]),
                        int.Parse(inputEngines[2]), inputEngines[3]);
                    engines.Add(currEngine);
                }
            }

            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < m; i++)
            {
                var inputCars = Console.ReadLine().Split().ToArray();
                if (inputCars.Length == 2)
                {
                    Car currCar = new Car(inputCars[0], inputCars[1]);
                    cars.Add(currCar);
                }
                else if (inputCars.Length == 3)
                {
                    int weight = 0;
                    if (Int32.TryParse(inputCars[2], out weight))
                    {
                        Car currCar = new Car(inputCars[0], inputCars[1], weight);
                        cars.Add(currCar);
                    }
                    else
                    {
                        Car currCar = new Car(inputCars[0], inputCars[1], inputCars[2]);
                        cars.Add(currCar);
                    }
                }
                else
                {
                    Car currCar = new Car(inputCars[0], inputCars[1],
                        int.Parse(inputCars[2]), inputCars[3]);
                    cars.Add(currCar);
                }
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine}:");
                foreach (var engine in engines)
                {
                    if (car.Engine == engine.Model)
                    {
                        Console.WriteLine($"    Power: {engine.Power}");
                        Console.WriteLine($"    Displacement: {engine.Displacement}");
                        Console.WriteLine($"    Efficiency: {engine.Efficiency}");
                    }
                }

                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}