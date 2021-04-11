using System;

namespace _05.CareOfPuppy
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodInGrams = int.Parse(Console.ReadLine()) * 1000;
            string input = Console.ReadLine();

            int totalEatenFood = 0;

            while (input!="Adopted")
            {
                totalEatenFood += int.Parse(input);

                input = Console.ReadLine();
            }

            if (totalEatenFood<=foodInGrams)
            {
                Console.WriteLine($"Food is enough! Leftovers: {foodInGrams-totalEatenFood} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {totalEatenFood-foodInGrams} grams more.");
            }
        }
    }
}
