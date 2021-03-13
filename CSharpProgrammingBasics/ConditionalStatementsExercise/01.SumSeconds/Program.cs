using System;

namespace _01.SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());

            int totalSeconds = firstTime + secondTime + thirdTime;

            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            Console.WriteLine($"{minutes}:{(seconds < 10 ? $"0{seconds}" : $"{seconds}")}");



        }
    }
}
