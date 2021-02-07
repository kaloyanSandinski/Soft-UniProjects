namespace RawData
{
    public class Tire
    {
        public Tire(int age1, double pressure1, int age2, double pressure2, int age3, double pressure3, int age4,
            double pressure4)
        {
            Tire1Age = age1;
            Tire1Pressure = pressure1;
            Tire2Age = age2;
            Tire2Pressure = pressure2;
            Tire3Age = age3;
            Tire3Pressure = pressure3;
            Tire4Age = age4;
            Tire4Pressure = pressure4;
        }

        public int Tire1Age { get; set; }
        public double Tire1Pressure { get; set; }
        public int Tire2Age { get; set; }
        public double Tire2Pressure { get; set; }
        public int Tire3Age { get; set; }
        public double Tire3Pressure { get; set; }
        public int Tire4Age { get; set; }
        public double Tire4Pressure { get; set; }
    }
}