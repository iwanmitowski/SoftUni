using System;

namespace _07.WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double distancePerMeter = double.Parse(Console.ReadLine());

            double currentTime = distance * distancePerMeter;
            double slow = Math.Floor(distance / 15) * 12.5;

            double totalTime = currentTime + slow;
            Math.Round(totalTime, 2);
            if (totalTime<record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {totalTime-record:f2} seconds slower.");
            }
        }
    }
}
