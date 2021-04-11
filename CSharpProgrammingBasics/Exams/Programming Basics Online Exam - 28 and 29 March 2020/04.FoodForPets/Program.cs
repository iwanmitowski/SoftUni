using System;

namespace _04.FoodForPets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double totalFood = double.Parse(Console.ReadLine());

            double totalDogFood = 0;
            double totalCatFood = 0;
            double biscuits = 0;

            for (int i = 1; i <= days; i++)
            {
                double currentDogFood = double.Parse(Console.ReadLine());
                double currentCatFood = double.Parse(Console.ReadLine());

                totalDogFood += currentDogFood;
                totalCatFood += currentCatFood;

                if (i%3==0)
                {
                    biscuits += (currentCatFood + currentDogFood) * 0.1;
                }
            }

            double totalEatenFood = totalCatFood + totalDogFood;

            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuits)}gr.");
            Console.WriteLine($"{totalEatenFood/totalFood*100:f2}% of the food has been eaten.");
            Console.WriteLine($"{totalDogFood/totalEatenFood*100:f2}% eaten from the dog.");
            Console.WriteLine($"{totalCatFood/totalEatenFood*100:f2}% eaten from the cat.");

        }
    }
}
