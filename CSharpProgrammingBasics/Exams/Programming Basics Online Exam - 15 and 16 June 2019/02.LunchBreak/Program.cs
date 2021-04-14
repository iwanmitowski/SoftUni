using System;

namespace _02.LunchBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            string series = Console.ReadLine();
            int episodeLength = int.Parse(Console.ReadLine());
            int breakLength = int.Parse(Console.ReadLine());

            double lunchTime = breakLength / 8.0;
            double restTime = breakLength / 4.0;

            double totalBreakTime = breakLength - lunchTime - restTime;

            if (totalBreakTime >= episodeLength)
            {
                Console.WriteLine($"You have enough time to watch {series} and left with {(int)Math.Ceiling(totalBreakTime-episodeLength)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {series}, you need {(int)Math.Ceiling(episodeLength-totalBreakTime)} more minutes.");
               
            }
        }
    }
}
