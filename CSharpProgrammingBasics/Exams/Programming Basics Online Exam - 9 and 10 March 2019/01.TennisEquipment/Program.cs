using System;

namespace _01.TennisEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceRocket = double.Parse(Console.ReadLine());
            int rocketsNumber = int.Parse(Console.ReadLine());
            int pairShoes = int.Parse(Console.ReadLine());

            double priceRockets = rocketsNumber * priceRocket;
            double pricePairShoes = priceRocket / 6;
            double priceAllShoes = pricePairShoes * pairShoes;
            double priceOtherEquipment = (priceRockets + priceAllShoes) * 0.2;
            double finalPrice = priceRockets + priceAllShoes + priceOtherEquipment;

            double priceDjokovic = finalPrice / 8;
            double priceSponsors = finalPrice * 7 / 8;

            Console.WriteLine(($"Price to be paid by Djokovic {Math.Floor(priceDjokovic)}"));
            Console.WriteLine(($"Price to be paid by sponsors {Math.Ceiling(priceSponsors)}"));
        }
    }
}
