using System;

namespace _03.Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal chrysanthemum = 0;
            decimal rose = 0;
            decimal tulip = 0;

            int chrysanthemumCount = int.Parse(Console.ReadLine());
            int roseCount = int.Parse(Console.ReadLine());
            int tulipCount = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            bool isHoliday = Console.ReadLine() == "Y" ? true : false;

            int arrangement = 2;
            decimal totalBudget = 0;

            switch (season)
            {
                case "Spring":
                case "Summer":
                    chrysanthemum = 2;
                    rose = 4.1M;
                    tulip = 2.5M;
                    break;
                case "Autumn":
                case "Winter":
                    chrysanthemum = 3.75M;
                    rose = 4.5M;
                    tulip = 4.15M;
                    break;
                default:
                    break;
            }

            if (isHoliday)
            {
                chrysanthemum *= 1.15M;
                rose *= 1.15M;
                tulip *= 1.15M;
            }

            totalBudget = chrysanthemum * chrysanthemumCount + rose * roseCount + tulip * tulipCount;

            if (season == "Spring" && tulipCount > 7)
            {
                totalBudget *= 0.95M;
            }
            else if (season == "Winter" && roseCount >= 10)
            {
                totalBudget *= 0.9M;
            }

            if (chrysanthemumCount + roseCount + tulipCount > 20)
            {
                totalBudget *= 0.8M;
            }

            totalBudget += arrangement;

            Console.WriteLine($"{totalBudget:f2}");
        }
    }
}
