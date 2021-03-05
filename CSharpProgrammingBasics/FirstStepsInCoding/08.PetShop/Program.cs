using System;

namespace _08.PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double dogPrice = 2.50;
            double othersPrice = 4;

            int dogCount = int.Parse(Console.ReadLine());
            int othersCount = int.Parse(Console.ReadLine());

            double sum = dogCount * dogPrice + othersCount * othersPrice;
            Console.WriteLine($"{sum} lv.");
        }
    }
}
