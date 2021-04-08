using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly IDictionary<string, ICar> carsByModel;

        public CarRepository()
        {
            carsByModel = new Dictionary<string, ICar>();
        }

        public ICar GetByName(string name)
        {
            ICar car = null;
            if (carsByModel.ContainsKey(name))
            {
                car = carsByModel[name];
            }

            return car;
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            ICollection<ICar> outputCars = new List<ICar>();
            foreach (var car in carsByModel)
            {
                outputCars.Add(car.Value);
            }

            return (IReadOnlyCollection<ICar>)outputCars;
        }

        public void Add(ICar model)
        {
            if (carsByModel.ContainsKey(model.Model))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CarExists, model.Model));
            }

            carsByModel.Add(model.Model, model);
        }

        public bool Remove(ICar model)
        {
            return this.carsByModel.Remove(model.Model);
        }
    }
}
