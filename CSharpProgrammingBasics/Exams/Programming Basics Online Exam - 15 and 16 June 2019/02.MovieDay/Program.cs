using System;

namespace _02.MovieDay
{
    class Program
    {
        static void Main(string[] args)
        {
            int shotsTime = int.Parse(Console.ReadLine());
            int scenesCount = int.Parse(Console.ReadLine());
            int sceneLength = int.Parse(Console.ReadLine());

            double setUp = shotsTime * 0.15;
            double totalTime = sceneLength * scenesCount + setUp;

            if (totalTime<=shotsTime)
            {
                Console.WriteLine($"You managed to finish the movie on time! You have {Math.Ceiling(shotsTime- totalTime)} minutes left!");
            }
            else
            {
                Console.WriteLine($"Time is up! To complete the movie you need {Math.Ceiling(totalTime- shotsTime)} minutes.");
            }
        }
    }
}
