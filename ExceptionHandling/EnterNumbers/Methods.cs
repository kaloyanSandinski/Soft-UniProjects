using System;
using System.Collections.Generic;
using System.Text;

namespace EnterNumbers
{
    public static class Methods
    {
        public static void ReadNumber(int start, int end)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    int n = int.Parse(Console.ReadLine());
                    if (n < start || n > end)
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid number");
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        int n = int.Parse(Console.ReadLine());
                        if (n < start || n > end)
                        {
                            throw new Exception();
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Invalid number");
                }
            }
        }
    }
}
