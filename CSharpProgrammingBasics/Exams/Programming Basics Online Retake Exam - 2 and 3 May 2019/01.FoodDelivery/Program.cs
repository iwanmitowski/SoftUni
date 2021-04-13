using System;

namespace _01.FoodDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            double chickenMenu = 10.35;
            double fishMenu = 12.4;
            double veganMenu = 8.15;

            double delivery = 2.50;

            int chickenCount = int.Parse(Console.ReadLine());
            int fishCount = int.Parse(Console.ReadLine());
            int veganCount = int.Parse(Console.ReadLine());

            double totalSum = chickenMenu * chickenCount + fishMenu * fishCount + veganMenu * veganCount;
            totalSum *= 1.2;
            totalSum += delivery;

            Console.WriteLine($"Total: {totalSum:f2}");
        }
    }
}
