using System;

namespace _01.PoolDay
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            double tax = double.Parse(Console.ReadLine());
            double deckChairPrice = double.Parse(Console.ReadLine());
            double umbrellaPrice = double.Parse(Console.ReadLine());

            double peopleWithDeckChair = Math.Ceiling(people * 0.75);
            double peopleWithUmbrella = Math.Ceiling(people / 2.0);

            double totalSum = people * tax + peopleWithDeckChair * deckChairPrice + peopleWithUmbrella * umbrellaPrice;

            Console.WriteLine($"{totalSum:f2} lv.");
        }
    }
}
