using System;

namespace _02.MountainRun
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentRecord = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timePerSecond = double.Parse(Console.ReadLine());

            
            double distanceForTime = distance * timePerSecond;
            double delay = Math.Floor(distance / 50)*30;
            double totalTime = distanceForTime + delay;

            if (totalTime>=currentRecord)
            {
                Console.WriteLine($"No! He was {totalTime-currentRecord:f2} seconds slower.");
            }
            else
            {
                Console.WriteLine($"Yes! The new record is {totalTime:f2} seconds.");
            }
        }
    }
}
