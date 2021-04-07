using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private ICollection<IDriver> drivers;

        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            drivers = new List<IDriver>();
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
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }
            }
        }

        public int Laps
        {
            get
            {
                return laps;
            }
            private set
            {
                if (value<1)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfLaps);
                }
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => (IReadOnlyCollection<IDriver>) this.drivers;
        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentException(ExceptionMessages.DriverInvalid);
            }

            if (driver.Car==null)
            {
                throw new ArgumentException(ExceptionMessages.DriverNotParticipate);
            }

            if (drivers.Contains(driver))
            {
                throw new ArgumentNullException(ExceptionMessages.DriverAlreadyAdded);
            }
        }
    }
}
