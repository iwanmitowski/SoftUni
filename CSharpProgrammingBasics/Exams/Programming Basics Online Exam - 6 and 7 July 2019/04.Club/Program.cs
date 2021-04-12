using System;

namespace _04.Club
{
    class Program
    {
        static void Main(string[] args)
        {
            double expectedMoney = double.Parse(Console.ReadLine());

            string cocktail = Console.ReadLine();
            int counter = 1;

            double totalMoney = 0;

            while (cocktail!="Party!")
            {
                int count = int.Parse(Console.ReadLine());
                int cocktailPrice = cocktail.Length;

                double currentSum = cocktailPrice * count;

                if (currentSum%2!=0)
                {
                    currentSum *= 0.75;
                }

                totalMoney += currentSum;

                if (totalMoney>=expectedMoney)
                {
                    Console.WriteLine("Target acquired.");
                    break;
                }

                cocktail = Console.ReadLine();
            }

            if (cocktail=="Party!")
            {
                Console.WriteLine($"We need {expectedMoney-totalMoney:f2} leva more.");
            }

            Console.WriteLine($"Club income - {totalMoney:f2} leva.");
        }
    }
}
