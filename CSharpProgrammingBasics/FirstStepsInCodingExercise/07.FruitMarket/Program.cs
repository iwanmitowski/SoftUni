using System;

namespace _07.FruitMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberriesPrice = double.Parse(Console.ReadLine());
            double bananasKg = double.Parse(Console.ReadLine());
            double orangesKg = double.Parse(Console.ReadLine());
            double raspberriesKg = double.Parse(Console.ReadLine());
            double strawberriesKg = double.Parse(Console.ReadLine());

            double raspberriesPrice = strawberriesPrice / 2;
            double oragnesPrice = raspberriesPrice - raspberriesPrice * 0.4;
            double bananasPrice = raspberriesPrice - raspberriesPrice * 0.8;

            double raspberiesSum = raspberriesPrice * raspberriesKg;
            double orangesSum = oragnesPrice * orangesKg;
            double bananasSum = bananasPrice * bananasKg;
            double strawberriesSum = strawberriesPrice * strawberriesKg;

            double totalSum = raspberiesSum + orangesSum + bananasSum + strawberriesSum;
            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
