namespace CarManufacturer
{
    public class Engine
    {
        private int horsePower;

        public int HorsePower
        {
            get { return this.horsePower; }
            set { this.horsePower = value; }
        }

        private double cubicCapacity;

        public double CubicCapacity
        {
            get { return this.cubicCapacity; }
            set { this.cubicCapacity = value; }
        }

        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
    }
}