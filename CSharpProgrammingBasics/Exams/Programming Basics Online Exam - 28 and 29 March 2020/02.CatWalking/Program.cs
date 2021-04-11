using System;

namespace _02.CatWalking
{
    class Program
    {
        static void Main(string[] args)
        {
            int minsPerDay = int.Parse(Console.ReadLine());
            int walksPerDay = int.Parse(Console.ReadLine());
            int calsPerDay = int.Parse(Console.ReadLine());

            int totalWalkingPerDay = minsPerDay * walksPerDay;
            int totalBurnedCals = totalWalkingPerDay * 5;

            int neededCals = calsPerDay / 2;

            if (totalBurnedCals>=neededCals)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {totalBurnedCals}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {totalBurnedCals}.");
            }
        }
    }
}
