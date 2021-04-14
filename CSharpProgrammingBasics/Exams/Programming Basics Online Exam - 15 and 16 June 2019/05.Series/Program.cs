using System;

namespace _05.Series
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int series = int.Parse(Console.ReadLine());

            double neededMoney = 0;

            for (int i = 0; i < series; i++)
            {
                string name = Console.ReadLine();
                double price = double.Parse(Console.ReadLine());
                switch (name)
                {
                    case "Thrones":
                        price /= 2;
                        break;
                    case "Lucifer":
                        price *= 0.6;
                        break;
                    case "Protector":
                        price *= 0.7;
                        break;
                    case "TotalDrama":
                        price *= 0.8;
                        break;
                    case "Area":
                        price *= 0.9;
                        break;
                }
                neededMoney += price;
            }

            if (budget>=neededMoney)
            {
                Console.WriteLine($"You bought all the series and left with {budget-neededMoney:f2} lv.");
            }
            else
            {
                Console.WriteLine($"You need {neededMoney-budget:f2} lv. more to buy the series!");
            }
        }
    }
}
