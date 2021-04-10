using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private ICollection<IAquarium> aquariums;
        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != "FreshwaterAquarium" && aquariumType != "SaltwaterAquarium")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAquariumType));
            }

            IAquarium aquarium;
            if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquarium.GetType().Name);
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != "Ornament" && decorationType != "Plant")
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidDecorationType));
            }

            IDecoration decoration;
            if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                decoration = new Ornament();
            }
            decorations.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decoration.GetType().Name);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = decorations.FindByType(decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration,
                    decorationType));
            }

            aquariums.FirstOrDefault(x => x.Name == aquariumName).AddDecoration(decoration);
            decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidFishType));
            }

            IFish fish;
            string output = String.Empty;
            if (fishType== "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }

            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            if (aquarium.GetType().Name== "SaltwaterAquarium" && fishType== "FreshwaterFish" || aquarium.GetType().Name == "FreshwaterAquarium" && fishType == "SaltwaterFish")
            {
                output = string.Format(OutputMessages.UnsuitableWater);
            }
            else
            {
                aquarium.AddFish(fish);
                output = string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }

            return output;
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.Feed();
            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            decimal sum = 0;
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            foreach (var fish in aquarium.Fish)
            {
                sum += fish.Price;
            }

            foreach (var aquariumDecoration in aquarium.Decorations)
            {
                sum += aquariumDecoration.Price;
            }

            return string.Format(OutputMessages.AquariumValue, aquariumName, sum);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
