using System;

namespace _05.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            decimal rentPrice = 0;
            string place = string.Empty;
            string location = string.Empty;

            switch (season)
            {
                case "Summer":
                    location = "Alaska";
                    break;
                case "Winter":
                    location = "Morocco";
                    break;
            }

            if (budget <= 1000)
            {
                place = "Camp";
            }
            else if (budget > 1000 && budget <= 3000)
            {
                place = "Hut";
            }
            else
            {
                place = "Hotel";
                rentPrice = budget * 0.9M;
            }

            switch (place)
            {
                case "Camp":
                    switch (location)
                    {
                        case "Alaska":
                            rentPrice = budget * 0.65M;
                            break;
                        case "Morocco":
                            rentPrice = budget * 0.45M;
                            break;
                    }
                    break;
                case "Hut":
                    switch (location)
                    {
                        case "Alaska":
                            rentPrice = budget * 0.8M;
                            break;
                        case "Morocco":
                            rentPrice = budget * 0.6M;
                            break;
                    }
                    break;
            }

            Console.WriteLine($"{location} - {place} - {rentPrice:f2}");
        }
    }
}
