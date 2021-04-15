using System;

namespace _02.Skeleton
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            int secondsPer100 = int.Parse(Console.ReadLine());

            int control = minutes * 60 + seconds;
            double time = length / 120;
            double totalDelayedTime = time * 2.5;
            double martinsTime = (length / 100) * secondsPer100 - totalDelayedTime;

            if (martinsTime<=control)
            {
                Console.WriteLine("Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {martinsTime:f3}.");
            }
            else
            {
                Console.WriteLine($"No, Marin failed! He was {martinsTime-control:f3} second slower.");
            }

        }
    }
}
