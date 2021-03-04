namespace Restaurant
{
    public class Coffee : HotBeverage
    {

        public Coffee(string name, double caffeine) : base(name, 50m, 3.5)
        {
            Caffeine = caffeine;
        }
        
        public double Caffeine { get; set; }
    }
}