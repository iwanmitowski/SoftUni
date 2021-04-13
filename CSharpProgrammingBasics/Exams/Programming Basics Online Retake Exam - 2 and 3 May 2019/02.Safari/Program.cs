using System;

namespace _02.Safari
{
    class Program
    {
        static void Main(string[] args)
        {
            double pricePerLiter = 2.1;
            int guide = 100;


            double budget = double.Parse(Console.ReadLine());
            double liters = double.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            double totalFuelPrice = liters * pricePerLiter;
            double totalSum = totalFuelPrice + guide;

            switch (day)
            {
                case "Saturday":
                    totalSum *= 0.9;
                    break;
                default:
                    totalSum *= 0.8;
                    break;
            }

            if (budget>=totalSum)
            {
                Console.WriteLine($"Safari time! Money left: {budget-totalSum:f2} lv. ");
            }
            else
            {
                Console.WriteLine($"Not enough money! Money needed: {totalSum-budget:f2} lv.");
            }

        }
    }
}
