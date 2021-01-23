using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine();
            HashSet<string> carsInParking = new HashSet<string>();
            while (tokens!="END")
            {
                var inputCmnd = tokens
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var direction = inputCmnd[0];
                var carNumber = inputCmnd[1];
                if (direction=="IN")
                {
                    carsInParking.Add(carNumber);
                }
                else
                {
                    carsInParking.Remove(carNumber);
                }

                tokens = Console.ReadLine();
            }

            if (carsInParking.Any())
            {
                foreach (var currCar in carsInParking)
                {
                    Console.WriteLine(currCar);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}