using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly IDictionary<string, IRace> racesByName;

        public RaceRepository()
        {
            racesByName = new Dictionary<string, IRace>();
        }
        public IRace GetByName(string name)
        {
            IRace race = null;
            if (racesByName.ContainsKey(name))
            {
                race = racesByName[name];
            }

            return race;
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            ICollection<IRace> driversOutput = new List<IRace>();
            foreach (var race in racesByName)
            {
                driversOutput.Add(race.Value);
            }

            return (IReadOnlyCollection<IRace>)driversOutput;
        }

        public void Add(IRace model)
        {
            if (racesByName.ContainsKey(model.Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RaceExists, model.Name));
            }

            racesByName.Add(model.Name, model);
        }

        public bool Remove(IRace model)
        {
            return this.racesByName.Remove(model.Name);
        }
    }
}
