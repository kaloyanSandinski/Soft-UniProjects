namespace RawData
{
    public class Engine
    {
        public Engine(int power, int speed)
        {
            Speed = speed;
            Power = power;
        }
        public int Speed { get; set; }
        public int Power { get; set; }
        
    }
}