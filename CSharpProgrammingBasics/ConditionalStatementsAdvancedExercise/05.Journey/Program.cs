using System;

namespace _05.Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = string.Empty;
            string place = string.Empty;
            double finalPrice = 0;

            if (season=="summer")
            {
                place = "Camp";
            }
            else
            {
                place = "Hotel";
            }

            if (budget <= 100)
            {
                destination = "Somewhere in Bulgaria";
                switch (season)
                {
                    case "summer":
                        finalPrice = budget * 0.3;
                        break;
                    case "winter":
                        finalPrice = budget * 0.7;
                        break;
                    default:
                        break;
                }
            }
            else if (budget > 100 && budget <= 1000)
            {
                destination = "Somewhere in Balkans";
                switch (season)
                {
                    case "summer":
                        finalPrice = budget * 0.4;
                        break;
                    case "winter":
                        finalPrice = budget * 0.8;
                        break;
                    default:
                        break;
                }
            }
            else if (budget > 1000)
            {
                destination = "Somewhere in Europe";
                finalPrice = budget * 0.9;
                place = "Hotel";
            }

            Console.WriteLine(destination);
            Console.WriteLine($"{place} - {finalPrice:f2}");

        }
    }
}
