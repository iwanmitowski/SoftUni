using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            string animalInput = Console.ReadLine();

            List<Animal> animals = new List<Animal>();

            while (animalInput != "End")
            {
                string foodInput = Console.ReadLine();

                string[] animalArgs = animalInput.Split();
                string[] foodArgs = foodInput.Split();

                try
                {
                    Animal animal = CreateAnimal(animalArgs);
                    Food food = CreateFood(foodArgs);

                    animals.Add(animal);
                    animal.ProduceSound();
                    animal.EatFood(food);

                }
                catch (Exception ife)
                {
                    Console.WriteLine(ife.Message);
                }

                animalInput = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        static Food CreateFood(string[] foodInfo)
        {
            var type = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);
            Food food = null;

            switch (type)
            {
                case "Vegetable":
                    food = new Vegetable(quantity);
                    break;
                case "Fruit":
                    food = new Fruit(quantity);
                    break;
                case "Meat":
                    food = new Meat(quantity);
                    break;
                case "Seeds":
                    food = new Seeds(quantity);
                    break;
                default:
                    break;
            }

            return food;
        }

        static Animal CreateAnimal(string[] animalInfo)
        {
            var type = animalInfo[0];
            var name = animalInfo[1];
            var weight = double.Parse(animalInfo[2]);

            Animal animal = null;

            if (type == "Owl")
            {
                double wingSize = double.Parse(animalInfo[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (type == "Hen")
            {
                double wingSize = double.Parse(animalInfo[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else if (type == "Mouse")
            {
                string livingRegion = animalInfo[3];
                animal = new Mouse(name, weight, livingRegion);
            }
            else if (type == "Dog")
            {
                string livingRegion = animalInfo[3];
                animal = new Dog(name, weight, livingRegion);
            }
            else if (type == "Cat")
            {
                string livingRegion = animalInfo[3];
                string breed = animalInfo[4];
                animal = new Cat(name, weight, livingRegion, breed);
            }
            else if (type == "Tiger")
            {
                string livingRegion = animalInfo[3];
                string breed = animalInfo[4];
                animal = new Tiger(name, weight, livingRegion, breed);
            }
            return animal;
        }
    }
}