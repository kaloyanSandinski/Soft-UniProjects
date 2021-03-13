using System;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split();
            var urls = Console.ReadLine().Split();

            Smartphone smartPhone = new Smartphone();
            StationaryPhone stationary = new StationaryPhone();
            foreach (var number in numbers)
            {
                try
                {
                    string result = number.Length == 10
                        ? smartPhone.CallOtherPhones(number)
                        : stationary.CallOtherPhones(number);

                    Console.WriteLine(result);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (var url in urls)
            {
                try
                {
                    string result = smartPhone.BrowseInWeb(url);

                    Console.WriteLine(result);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
