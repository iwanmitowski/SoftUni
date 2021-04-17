using System;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            double wish = 0.6;
            double rose = 7.2;
            double keyHolder = 3.6;
            double drawing = 18.2;
            double surprise = 22;

            double price = double.Parse(Console.ReadLine());
            int wishesCount = int.Parse(Console.ReadLine());
            int rosesCount = int.Parse(Console.ReadLine());
            int keysCount = int.Parse(Console.ReadLine());
            int drawingsCount = int.Parse(Console.ReadLine());
            int surprisesCount = int.Parse(Console.ReadLine());

            double totalSum = wish * wishesCount + rose * rosesCount + keyHolder * keysCount + drawing * drawingsCount + surprise * surprisesCount;
            int totalCount = wishesCount + rosesCount + keysCount + drawingsCount + surprisesCount;

            if (totalCount>=25)
            {
                totalSum *= 0.65;
            }

            totalSum *= 0.9;

            if (totalSum>=price)
            {
                Console.WriteLine($"Yes! {totalSum-price:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {price-totalSum:f2} lv needed.");
            }
        }
    }
}
