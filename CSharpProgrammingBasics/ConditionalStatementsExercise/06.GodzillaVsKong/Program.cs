using System;

namespace _06.GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double movieBudget = double.Parse(Console.ReadLine());
            int statists = int.Parse(Console.ReadLine());
            double clothesPrice = double.Parse(Console.ReadLine());

            double decoration = movieBudget * 0.1;

            if (statists>150)
            {
                clothesPrice *= 0.9;
            }

            double priceForAllClothes = clothesPrice * statists;

            double costs =  priceForAllClothes + decoration;

            if (movieBudget>=costs)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {movieBudget-costs:f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {costs-movieBudget:f2} leva more.");

            }

        }
    }
}
