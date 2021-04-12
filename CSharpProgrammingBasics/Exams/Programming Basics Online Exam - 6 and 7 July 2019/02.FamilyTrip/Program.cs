using System;

namespace _02.FamilyTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int nightStands = int.Parse(Console.ReadLine());
            double pricePerNightStand = double.Parse(Console.ReadLine());
            int percent = int.Parse(Console.ReadLine());

            if (nightStands>7)
            {
                pricePerNightStand *= 0.95;
            }

            double totalSum = nightStands * pricePerNightStand;
            double bonus = (budget * percent) / 100;
            totalSum += bonus;

            if (budget>=totalSum)
            {
                Console.WriteLine($"Ivanovi will be left with {budget-totalSum:f2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{totalSum-budget:f2} leva needed.");
            }

        }
    }
}
