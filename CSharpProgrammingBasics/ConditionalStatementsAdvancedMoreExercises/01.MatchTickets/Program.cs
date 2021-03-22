using System;

namespace _01.MatchTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());

            decimal normal = 249.99M;
            decimal vip = 499.99M;

            if (people <= 4)
            {
                budget *= 0.25M;
            }
            else if (people >= 5 && people <= 9)
            {
                budget *= 0.4M;
            }
            else if (people >= 10 && people <= 24)
            {
                budget *= 0.5M;
            }
            else if (people >= 25 && people <= 49)
            {
                budget *= 0.6M;
            }
            else
            {
                budget *= 0.75M;
            }

            decimal neededMoney = 0;

            switch (category)
            {
                case "VIP":
                    neededMoney = vip * people;
                    break;
                case "Normal":
                    neededMoney = normal * people;
                    break;
            }

            if (neededMoney>budget)
            {
                Console.WriteLine($"Not enough money! You need {neededMoney-budget:f2} leva.");
            }
            else
            {
                Console.WriteLine($"Yes! You have {budget-neededMoney:f2} leva left.");
            }
        }
    }
}
