using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public decimal Cost
        {
            get { return cost; }
            set
            {
                Validator.ThrowIfNumberIsNotValid(value, "Money cannot be negative");
                cost = value;
            }
        }


        public string Name
        {
            get { return name; }
            set
            {
                Validator.ThrowIfStringIsNotValid(value, "Name cannot be empty");
                name = value;
            }
        }

    }
}
