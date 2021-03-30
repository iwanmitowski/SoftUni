using System;

namespace _06.Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());

            int water = 20;
            int internet = 15;

            decimal totalElectricity = 0;
            decimal totalWater = months*water;
            decimal totalInternet = months*internet;
            decimal others = 0;

            for (int i = 0; i < months; i++)
            {
                decimal electricty = decimal.Parse(Console.ReadLine());
                totalElectricity += electricty;
                others += (water + internet + electricty) * 1.2M;

            }

            double averageSum = (double)(totalElectricity+totalWater+totalInternet+others)/months;

            Console.WriteLine($"Electricity: {totalElectricity:f2} lv");
            Console.WriteLine($"Water: {totalWater:f2} lv");
            Console.WriteLine($"Internet: {totalInternet:f2} lv");
            Console.WriteLine($"Other: {others:f2} lv");
            Console.WriteLine($"Average: {averageSum:f2} lv");
        }
    }
}
