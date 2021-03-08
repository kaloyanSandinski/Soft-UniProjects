using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var people = new Dictionary<string, Person>();
            var products = new Dictionary<string, Product>();
            try
            {
                people = ReadPeople();
                products = ReadProducts();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            string command = Console.ReadLine();
            while (command != "END")
            {
                var data = command.Split().ToArray();
                var personName = data[0];
                var wantedProduct = data[1];
                var currPerson = people[personName];
                var currProduct = products[wantedProduct];

                try
                {
                    currPerson.BuyProduct(currProduct);

                    Console.WriteLine($"{currPerson.Name} bought {currProduct.Name}");
                }
                catch (InvalidOperationException exception)
                {
                    Console.WriteLine(exception.Message);
                }

                command = Console.ReadLine();
            }

            foreach (var currPerson in people.Values)
            {
                Console.WriteLine(currPerson);
            }
        }



        private static Dictionary<string, Product> ReadProducts()
        {
            var result = new Dictionary<string, Product>();

            var input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            foreach (var data in input)
            {
                var productData = data.Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var productName = productData[0];
                var productPrice = decimal.Parse(productData[1]);
                
                    Product product = new Product(productName, productPrice);
                    result.Add(productName, product);
            }

            return result;
        }

        private static Dictionary<string, Person> ReadPeople()
        {
            var result = new Dictionary<string, Person>();

            var input = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            foreach (var data in input)
            {
                var personData = data.Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var personName = personData[0];
                var personMoney = decimal.Parse(personData[1]);
                    Person person = new Person(personName, personMoney);
                    result.Add(personName, person);
            }
            return result;
        }
    }
}
