using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        //Each person should have a name, money and a bag of products. 
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();
        }
        
        public decimal Money
        {
            get { return money; }
            set
            {
                Validator.ThrowIfNumberIsNotValid(value, "Money cannot be negative");
                money = value;
            }
        }


        public string Name
        {
            get { return name; }
            private set
            {
                Validator.ThrowIfStringIsNotValid(value, "Name cannot be empty");
                name = value;
            }
        }

        public void BuyProduct(Product product)
        {
            if (Money - product.Cost >= 0)
            {
                Money -= product.Cost;
                bagOfProducts.Add(product);
            }
            else
            {
                throw new InvalidOperationException($"{Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            if (this.bagOfProducts.Count>0)
            {
                return $"{this.Name} - {string.Join(", ", this.bagOfProducts.Select(x=>x.Name))}";
            }

            return $"{Name} - Nothing bought";
        }
    }
}
