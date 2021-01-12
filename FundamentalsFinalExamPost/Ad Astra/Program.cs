using System;
using System.Text.RegularExpressions;

namespace Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();
            Regex regex =
                new Regex(@"(#|\|)(?<itemName>[A-z]+|[A-z]+\s[A-z]+)\1(?<expirationDate>\d{2}/\d{2}/\d{2})\1(?<calories>\d+)\1"); 
            MatchCollection matchedItems = regex.Matches(inputText);
            int allCalories = 0;
            foreach (Match items in matchedItems)
            {
                allCalories += int.Parse(items.Groups["calories"].Value);
            }

            int amountOfDays = allCalories / 2000;

            Console.WriteLine($"You have food to last you for: {amountOfDays} days!");
            foreach (Match item in matchedItems)
            {
                Console.WriteLine(
                    $"Item: {item.Groups["itemName"]}, Best before: {item.Groups["expirationDate"]}, Nutrition: {item.Groups["calories"]}");
            }
        }
    }
}