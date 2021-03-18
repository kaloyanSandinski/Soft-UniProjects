using System;
using System.Collections.Generic;
using System.Linq;
using WildFarm.Foods;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            //The Animal, Bird, Mammal, Feline and Food classes should be abstract. 
            string command = Console.ReadLine();
            List<Animal> allAnimals = new List<Animal>();

            while (command != "End")
            {
                var inputData = command.Split().ToArray();
                var foodInput = Console.ReadLine().Split().ToArray();
                Animal animal = ProduceAnimal(inputData);
                allAnimals.Add(animal);
                Food food = FoodCreator(foodInput[0], int.Parse(foodInput[1]));
                animal.AskForFood();
                try
                {
                    animal.Eat(food);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                command = Console.ReadLine();
            }

            foreach (var currAnimal in allAnimals)
            {
                Console.WriteLine(currAnimal);
            }
        }

        public static Animal ProduceAnimal(string[] inputData)
        {
            string typeAnimal = inputData[0];
            string nameAnimal = inputData[1];
            double weightAnimal = double.Parse(inputData[2]);
            Animal animal = null;
            if (typeAnimal == "Owl")
            {
                animal = new Owl(nameAnimal, weightAnimal, double.Parse(inputData[3]));
            }
            else if (typeAnimal == "Hen")
            {
                animal = new Hen(nameAnimal, weightAnimal, double.Parse(inputData[3]));
            }
            else if (typeAnimal == "Dog")
            {
                animal = new Dog(nameAnimal, weightAnimal, inputData[3]);
            }
            else if (typeAnimal == "Mouse")
            {
                animal = new Mouse(nameAnimal, weightAnimal, inputData[3]);
            }
            else if (typeAnimal == "Cat")
            {
                animal = new Cat(nameAnimal, weightAnimal, inputData[3], inputData[4]);
            }
            else if (typeAnimal == "Tiger")
            {
                animal = new Tiger(nameAnimal, weightAnimal, inputData[3], inputData[4]);
            }

            return animal;
        }

        public static Food FoodCreator(string foodType, int quantity)
        {
            Food food = null;
            if (foodType=="Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (foodType =="Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (foodType=="Meat")
            {
                food = new Meat(quantity);
            }
            else if (foodType=="Seeds")
            {
                food = new Seeds(quantity);
            }

            return food;
        }
    }
}
