using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Puppy puppy = new Puppy();
            Dog dog = new Dog();
            puppy.Weep();
            puppy.Bark();
            puppy.Eat();
            dog.Bark();
            dog.Eat();
        }
    }
}