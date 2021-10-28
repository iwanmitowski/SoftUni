using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var animals = new List<Animal>();

            string input = Console.ReadLine();

            while (input != "Beast!")
            {
                string[] animalArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = animalArgs[0];
                int age = int.Parse(animalArgs[1]);
                string gender = animalArgs[2];
                Animal animal = null;

                try
                {
                    switch (input)
                    {
                        case "Dog":
                            animal = new Dog(name, age, gender);
                            break;
                        case "Cat":
                            animal = new Cat(name, age, gender);
                            break;
                        case "Frog":
                            animal = new Frog(name, age, gender);
                            break;
                        case "Kitten":
                            animal = new Kitten(name, age);
                            break;
                        case "Tomcat":
                            animal = new Tomcat(name, age);
                            break;
                        default:
                            throw new InvalidOperationException("Invalid input!");
                    }

                    animals.Add(animal);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
                animal.ProduceSound();
            }
        }
    }
}

