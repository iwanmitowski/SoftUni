using System;

namespace _01.SeriesCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string series = Console.ReadLine();
            int seasons = int.Parse(Console.ReadLine());
            int episodes = int.Parse(Console.ReadLine());
            int noAds = int.Parse(Console.ReadLine());

            double ads = noAds * 0.2;
            int bonusTime = 10 * seasons;
            int totalLength = (int)Math.Floor((noAds + ads)*episodes*seasons+bonusTime);

            Console.WriteLine($"Total time needed to watch the {series} series is {totalLength} minutes.");
            
        }
    }
}
