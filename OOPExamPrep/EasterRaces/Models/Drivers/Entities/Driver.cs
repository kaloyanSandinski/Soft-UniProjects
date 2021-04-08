using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        private bool canPredicate = false;
        private ICar car;
        private int numberOfWins;

        public Driver(string name)
        {
            Name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)||value.Length<5)
                {
                    throw new ArgumentException($"Name {Name} cannot be less than 5 symbols.");
                }

                name = value;
            }
        }

        public ICar Car
        {
            get
            {
                return car;
            }
            private set
            {
                car = value;
            }
        }

        public int NumberOfWins
        {
            get
            {
                return numberOfWins;
            }
            private set
            {
                numberOfWins = value;
            }
        }

        public bool CanParticipate
        {
            get
            {
                return canPredicate;
            }
            private set
            {
                if (Car!=null)
                {
                    canPredicate = true;
                }
            }
        }

        public void WinRace()
        {
            NumberOfWins += 1;
        }

        public void AddCar(ICar car)
        {
            if (car==null)
            {
                throw new ArgumentException("Car cannot be null.");
            }

            Car = car;
            CanParticipate = true;
        }
    }
}
