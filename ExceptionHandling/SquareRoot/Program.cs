using System;

namespace SquareRoot
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                if (n<0)
                {
                    throw new Exception();
                }

                Console.WriteLine(Math.Sqrt(n));
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
