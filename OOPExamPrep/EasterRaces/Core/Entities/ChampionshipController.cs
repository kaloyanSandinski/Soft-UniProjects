using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Dynamic;
using System.Linq;
using System.Text;
using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository carRepository;
        private DriverRepository driverRepository;
        private RaceRepository raceRepository;
        public ChampionshipController()
        {
            carRepository = new CarRepository();
            driverRepository = new DriverRepository();
            raceRepository = new RaceRepository();
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);
            if (driverRepository.GetAll().Contains(driver))
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            driverRepository.Add(driver);
            return $"Driver {driverName} is created.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            if (carRepository.GetAll().Contains(car))
            {
                throw new ArgumentException($"Car {model} is already created.");
            }

            carRepository.Add(car);
            return $"{car.GetType().Name} {car.Model} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            if (raceRepository.GetByName(name)!=null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            IRace race = new Race(name, laps);
            raceRepository.Add(race);
            return $"Race {race.Name} is created.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IDriver driver = null;
            if (raceRepository.GetByName(raceName)==null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (driverRepository.GetByName(driverName)==null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            driver = driverRepository.GetByName(driverName);
            raceRepository.GetByName(raceName).AddDriver(driver);
            return $"Driver {driverName} added in {raceName} race.";
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = null;
            ICar car = null;
            if (driverRepository.GetByName(driverName)==null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            if (carRepository.GetByName(carModel)==null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            car = carRepository.GetByName(carModel);
            driver = driverRepository.GetByName(driverName);
            driver.AddCar(car);
            return $"Driver {driver.Name} received car {car.Model}.";
        }

        public string StartRace(string raceName)
        {
            if (raceRepository.GetByName(raceName)==null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (raceRepository.GetByName(raceName).Drivers.Count<3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            IRace race = raceRepository.GetByName(raceName);
            List<IDriver> results = new List<IDriver>(race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)));

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Driver {results[0].Name} wins {raceName} race.")
                .AppendLine($"Driver {results[1].Name} is second in {raceName} race.")
                .AppendLine($"Driver {results[2].Name} is third in {raceName} race.");
            raceRepository.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}
