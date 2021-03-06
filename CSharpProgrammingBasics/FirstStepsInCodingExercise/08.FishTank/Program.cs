using System;

namespace _08.FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double V = length * width * height;

            double liters = V * 0.001;
            double percentage = percent * 0.01;

            double totalLiters = liters * (1 - percentage);

            Console.WriteLine(totalLiters);
        }
    }
}
