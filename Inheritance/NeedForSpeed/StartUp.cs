using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SportCar sportCar = new SportCar(100, 100);
            sportCar.Drive(5);
        }
    }
}