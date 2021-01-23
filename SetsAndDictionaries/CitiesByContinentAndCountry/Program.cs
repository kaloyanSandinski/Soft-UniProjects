using System;
using System.Collections.Generic;
using System.Linq;

namespace CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCountries = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> allCountries =
                new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < numberOfCountries; i++)
            {
                var currCountry = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var continent = currCountry[0];
                var country = currCountry[1];
                var city = currCountry[2];
                if (allCountries.ContainsKey(continent))
                {
                    if (allCountries[continent].ContainsKey(country))
                    {
                        allCountries[continent][country].Add(city);
                    }
                    else
                    {
                        allCountries[continent].Add(country, new List<string>());
                        allCountries[continent][country].Add(city);
                    }
                    
                }
                else
                {
                    allCountries.Add(continent, new Dictionary<string, List<string>>());
                    allCountries[continent].Add(country, new List<string>());
                    allCountries[continent][country].Add(city);
                }
            }

            foreach (var currContinent in allCountries)
            {
                Console.WriteLine($"{currContinent.Key}:");
                foreach (var currCountry in currContinent.Value)
                {
                    Console.WriteLine($"{currCountry.Key} -> {string.Join(", ", currCountry.Value)}");
                }
            }
        }
    }
}