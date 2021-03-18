using System;

namespace FixingVol2
{
    public class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            byte result;

            num1 = 30;
            num2 = 60;
            try
            {
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine($"{num1} * {num2} = {result}");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
