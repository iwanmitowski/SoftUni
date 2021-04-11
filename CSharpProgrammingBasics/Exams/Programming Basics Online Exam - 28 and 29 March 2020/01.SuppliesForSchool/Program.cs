using System;

namespace _01.SuppliesForSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            double pen = 5.80;
            double marker = 7.20;
            double detregentPerLiter = 1.20;

            int penCount = int.Parse(Console.ReadLine());
            int markersCount = int.Parse(Console.ReadLine());
            double liters = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double totalPen = pen * penCount;
            double totalMarkers = marker * markersCount;
            double totalDetergent = detregentPerLiter * liters;

            double totalSum = (totalPen + totalMarkers + totalDetergent);
            totalSum -= (totalSum * discount) / 100;

            Console.WriteLine($"{totalSum:f3}");
        }
    }
}
