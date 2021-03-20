using System;

namespace _12.TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            decimal money = decimal.Parse(Console.ReadLine());
            double percent = 0;
            switch (town)
            {
                case "Sofia":
                    if (money >= 0 && money <= 500)
                    {
                        percent = 0.05;
                    }
                    else if (money > 500 && money <= 1000)
                    {
                        percent = 0.07;
                    }
                    else if (money > 1000 && money <= 10000)
                    {
                        percent = 0.08;
                    }
                    else if (money > 10000)
                    {
                        percent = 0.12;

                    }
                    else
                    {
                        Console.WriteLine("error");
                        Environment.Exit(0);
                    }
                    break;
                case "Varna":
                    if (money >= 0 && money <= 500)
                    {
                        percent = 0.045;
                    }
                    else if (money > 500 && money <= 1000)
                    {
                        percent = 0.075;
                    }
                    else if (money > 1000 && money <= 10000)
                    {
                        percent = 0.1;
                    }
                    else if (money > 10000)
                    {
                        percent = 0.13;

                    }
                    else
                    {
                        Console.WriteLine("error");
                        Environment.Exit(0);
                    }
                    break;
                case "Plovdiv":
                    if (money >= 0 && money <= 500)
                    {
                        percent = 0.055;
                    }
                    else if (money > 500 && money <= 1000)
                    {
                        percent = 0.08;
                    }
                    else if (money > 1000 && money <= 10000)
                    {
                        percent = 0.12;
                    }
                    else if (money > 10000)
                    {
                        percent = 0.145;

                    }
                    else
                    {
                        Console.WriteLine("error");
                        Environment.Exit(0);
                    }
                    break;

                default:
                    Console.WriteLine("error");
                    Environment.Exit(0);
                    break;
            }

            Console.WriteLine($"{money * (decimal)percent:f2}");
        }
    }
}
