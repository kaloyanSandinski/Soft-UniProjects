using System;
using System.Collections.Generic;
using System.Text;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Models.Fish
{
    public  abstract class Fish : IFish
    {
        private string name;
        private string species;
        private int size;
        private decimal price;

        public Fish(string name, string species, decimal price)
        {
            Name = name;
            Species = species;
            Price = price;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidFishName));
                }

                name = value;
            }
        }

        public string Species
        {
            get
            {
                return species;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidFishSpecies));
                }

                species = value;
            }
        }

        public int Size
        {
            get
            {
                return size;
            }
            protected set
            {
                size = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidFishPrice));
                }

                price = value;
            }
        }

        public abstract void Eat();
    }
}
