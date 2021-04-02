using System;

namespace _02.ReportSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int neededMoney = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            int counter = 0;
            //0 - cash
            //1 - card
            int cash = 0;
            int card = 0;

            int cashCount = 0;
            int cardCount = 0;

            while (input != "End")
            {
                int money = int.Parse(input);

                if (counter % 2 == 0)
                {
                    if (money > 100)
                    {
                        Console.WriteLine("Error in transaction!");
                        counter++;
                        input = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        cash += money;
                        cashCount++;
                    }
                }
                else
                {
                    if (money < 10)
                    {
                        Console.WriteLine("Error in transaction!");
                        counter++;
                        input = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        card += money;
                        cardCount++;
                    }

                }

                Console.WriteLine("Product sold!");

                if (card + cash >= neededMoney)
                {
                    double totalSumCash = cash * 1.0 / cashCount;
                    double totalSumCard = card * 1.0 / cardCount;
                    Console.WriteLine($"Average CS: {totalSumCash:F2}");
                    Console.WriteLine($"Average CC: {totalSumCard:F2}");
                    Environment.Exit(0);
                }

                counter++;
                input = Console.ReadLine();
            }

            Console.WriteLine("Failed to collect required money for charity.");
        }
    }
}

