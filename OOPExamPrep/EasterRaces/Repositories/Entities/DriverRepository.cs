using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly IDictionary<string, IDriver> driversByName;

        public DriverRepository()
        {
            driversByName = new Dictionary<string, IDriver>();
        }
        public IDriver GetByName(string name)
        {
            IDriver driver = null;
            if (driversByName.ContainsKey(name))
            {
                driver = driversByName[name];
            }

            return driver;
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            ICollection<IDriver> driversOutput = new List<IDriver>();
            foreach (var car in driversByName)
            {
                driversOutput.Add(car.Value);
            }

            return (IReadOnlyCollection<IDriver>)driversOutput;
        }

        public void Add(IDriver model)
        {
            if(driversByName.ContainsKey(model.Name))
            {
                throw new ArgumentException(ExceptionMessages.CarExists);
            }

            driversByName.Add(model.Name, model);
        }

        public bool Remove(IDriver model)
        {
            return this.driversByName.Remove(model.Name);
        }
    }
}
