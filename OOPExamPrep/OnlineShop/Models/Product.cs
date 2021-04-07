using System;
using System.Collections.Generic;
using System.Text;
using OnlineShop.Common.Constants;

namespace OnlineShop.Models.Products
{
    public abstract class Product : IProduct
    {
        private int id;
        private string manufacturer;
        private string model;
        private decimal price;
        private double overallPerformance;

        public Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            OverallPerformance = overallPerformance;
        }

        public virtual double OverallPerformance
        {
            get
            {
                return overallPerformance;
            }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOverallPerformance);
                }

                overallPerformance = value;
            }
        }

        public virtual decimal Price
        {
            get
            {
                return price;
            }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }

                price = value;
            }
        }

        public string Model
        {
            get
            {
                return model;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidModel);
                }

                model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidManufacturer);
                }

                manufacturer = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidProductId);
                }

                id = value;
            }
        }

        public override string ToString()
        {
            return string.Format(SuccessMessages.ProductToString,
                this.OverallPerformance.ToString("f2"),
                this.Price.ToString("f2"),
                this.GetType().Name,
                this.Manufacturer,
                this.Model,
                this.Id);
        }
    }
}
