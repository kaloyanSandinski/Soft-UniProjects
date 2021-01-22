using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string token = Console.ReadLine();
            Dictionary<string, Dictionary<string, double>> allShops =
                new Dictionary<string, Dictionary<string, double>>();
            while (token != "Revision")
            {
                var currComand = token
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var shopName = currComand[0];
                var grocery = currComand[1];
                var price = double.Parse(currComand[2]);
                if (allShops.ContainsKey(shopName))
                {
                    allShops[shopName].Add(grocery, price);
                }
                else
                {
                    allShops.Add(shopName, new Dictionary<string, double>());
                    allShops[shopName].Add(grocery, price);
                }

                token = Console.ReadLine();
            }

            allShops = allShops
                .OrderBy(x => x.Key)
                .ToDictionary(a => a.Key, a => a.Value);
            foreach (var currShop in allShops)
            {
                Console.WriteLine($"{currShop.Key}->");
                foreach (var currProduct in currShop.Value)
                {
                    Console.WriteLine($"Product: {currProduct.Key}, Price: {currProduct.Value}");
                }
            }
        }
    }
}