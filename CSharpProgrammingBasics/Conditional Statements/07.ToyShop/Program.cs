using System;

namespace _07.ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double puzzle = 2.60;
            int doll = 3;
            double bear = 4.10;
            double minion = 8.20;
            int truck = 2;

            double vacantion = double.Parse(Console.ReadLine());
            int puzzleCount = int.Parse(Console.ReadLine());
            int dollsCount = int.Parse(Console.ReadLine());
            int bearsCount = int.Parse(Console.ReadLine());
            int minionsCount = int.Parse(Console.ReadLine());
            int trucksCount = int.Parse(Console.ReadLine());

            double puzzlesPrice = puzzle * puzzleCount;
            double dollsPrice = doll * dollsCount;
            double bearsPrice = bear * bearsCount;
            double minionsPrice = minion * minionsCount;
            double trucksPrice = truck * trucksCount;

            double totalSum = puzzlesPrice + dollsPrice + bearsPrice + minionsPrice + trucksPrice;

            int toysCount = puzzleCount + dollsCount + bearsCount + minionsCount + trucksCount;

            if (toysCount>=50)
            {
                totalSum *= 0.75;
            }

            totalSum *= 0.9;

            if (totalSum>=vacantion)
            {
                Console.WriteLine($"Yes! {totalSum-vacantion:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {vacantion-totalSum:f2} lv needed.");
            }

        }
    }
}
