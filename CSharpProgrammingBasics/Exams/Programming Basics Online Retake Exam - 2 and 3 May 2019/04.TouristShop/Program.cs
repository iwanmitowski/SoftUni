using System;

namespace _04.TouristShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            string product = Console.ReadLine();
            int products = 0;
            double productsPrice = 0;

            while (product != "Stop")
            {
                double price = double.Parse(Console.ReadLine());
                products++;

                if (products % 3==0)
                {
                    price /= 2;
                }

                if (price <= budget)
                {
                    budget -= price;
                    productsPrice += price;
                }
                else
                {
                    Console.WriteLine("You don't have enough money!");
                    Console.WriteLine($"You need {price - budget:f2} leva!");
                    products--;
                    Environment.Exit(0);
                }

                product = Console.ReadLine();

            }
            Console.WriteLine($"You bought {products} products for {productsPrice:f2} leva.");
        }
    }
}
