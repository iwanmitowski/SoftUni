using System;

namespace _03.Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            double grapePerKm = double.Parse(Console.ReadLine());
            int neededLiters = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double totalGrape = fieldSize * grapePerKm;
            double wine = (totalGrape * 0.4) / 2.5;

            if (neededLiters<=wine)
            {
                double leftWine = wine - neededLiters;
                double winePerPerson = leftWine / workers;

                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wine)} liters.");
                Console.WriteLine($"{Math.Ceiling(leftWine)} liters left -> {Math.Ceiling(winePerPerson)} liters per person.");
            }
            else
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(neededLiters-wine)} liters wine needed.");
            }
        }
    }
}
