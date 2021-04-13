using System;

namespace _03.MobileOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            string contract = Console.ReadLine();
            string typeContract = Console.ReadLine();
            string internet = Console.ReadLine();
            int months = int.Parse(Console.ReadLine());

            double pricePerMonth = 0;

            switch (typeContract)
            {
                case "Small":
                    switch (contract)
                    {
                        case "one":
                            pricePerMonth = 9.98;
                            break;
                        case "two":
                            pricePerMonth = 8.58;
                            break;
                    }
                    break;
                case "Middle":
                    switch (contract)
                    {
                        case "one":
                            pricePerMonth = 18.99;
                            break;
                        case "two":
                            pricePerMonth = 17.09;
                            break;
                    }
                    break;
                case "Large":
                    switch (contract)
                    {
                        case "one":
                            pricePerMonth = 25.98;
                            break;
                        case "two":
                            pricePerMonth = 23.59;
                            break;
                    }
                    break;
                case "ExtraLarge":
                    switch (contract)
                    {
                        case "one":
                            pricePerMonth = 35.99;
                            break;
                        case "two":
                            pricePerMonth = 31.79;
                            break;
                    }
                    break;
            }

            if (internet=="yes")
            {
                if (pricePerMonth<=10)
                {
                    pricePerMonth += 5.50;
                }
                else if (pricePerMonth>10&&pricePerMonth<=30)
                {
                    pricePerMonth += 4.35;
                }
                else
                {
                    pricePerMonth += 3.85;
                }
            }

            double totalSum = pricePerMonth * months;

            if (contract=="two")
            {
                totalSum *= 0.9625;
            }

            Console.WriteLine($"{totalSum:f2} lv.");

        }
    }
}
