using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string inputCmnd = Console.ReadLine();
            List<Animal> animals = new List<Animal>();
            while (inputCmnd!="Beast!")
            {
                var animalInfo = Console.ReadLine().Split().ToArray();
                if (int.Parse(animalInfo[1])<0)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    if (inputCmnd == "Cat")
                    {
                        Cat cat = new Cat(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                        animals.Add(cat);
                    }
                    else if (inputCmnd == "Dog")
                    {
                        Dog dog = new Dog(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                        animals.Add(dog);
                    }
                    else if (inputCmnd == "Frog")
                    {
                        Frog frog = new Frog(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                        animals.Add(frog);
                    }
                    else if (inputCmnd == "Kitten")
                    {
                        if (animalInfo.Length > 2)
                        {
                            Animal animal = new Animal(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                            animals.Add(animal);
                        }
                        else
                        {
                            Kitten kitten = new Kitten(animalInfo[0], int.Parse(animalInfo[1]));
                            animals.Add(kitten);
                        }
                    }
                    else
                    {
                        if (animalInfo.Length > 2)
                        {
                            Animal animal = new Animal(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                            animals.Add(animal);
                        }
                        else
                        {
                            Tomcat tomcat = new Tomcat(animalInfo[0], int.Parse(animalInfo[1]));
                            animals.Add(tomcat);
                        }
                    }
                }

                inputCmnd = Console.ReadLine();
            }

            foreach (var currAnimal in animals)
            {
                Console.WriteLine(currAnimal.GetType().Name);
                Console.WriteLine($"{currAnimal.Name} {currAnimal.Age} {currAnimal.Gender}");
                Console.WriteLine(currAnimal.ProduceSound());
            }
        }
    }
}