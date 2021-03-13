using System;

namespace _02.SleepyTomCat
{
    class Program
    {
        static void Main(string[] args)
        {
            int requiredSleep = 30000;

            int restDays = int.Parse(Console.ReadLine());
            int workDays = 365 - restDays;

            int playRestingDays = restDays * 127;
            int playWorkingDays = workDays * 63;

            int totalPlayTime = playRestingDays + playWorkingDays;

            int timeDiff = Math.Abs(requiredSleep - totalPlayTime);

            int hours = timeDiff / 60;
            int minutes = timeDiff % 60;

            if (totalPlayTime<requiredSleep)
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{hours} hours and {minutes} minutes less for play");
            }
            else
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{hours} hours and {minutes} minutes more for play");
            }

        }
    }
}
