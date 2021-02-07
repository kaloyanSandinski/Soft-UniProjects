namespace CarSalesman
{
    public class Car
    {
        public Car(string model, string engine)
        {
            Model = model;
            Engine = engine;
            Weight = "n/a";
            Color = "n/a";
        }

        public Car(string model, string engine, int weight):this(model, engine)
        {
            Weight = weight.ToString();
        }

        public Car(string model, string engine, string color):this(model, engine)
        {
            Color = color;
        }

        public Car(string model, string engine, int weight, string color):this(model, engine, weight)
        {
            Color = color;
        }
        public string Model { get; set; }
        public string Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }
    }
}