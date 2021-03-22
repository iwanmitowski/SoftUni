using System;

namespace _04.CarToGo
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string classCategory = string.Empty;
            string car = string.Empty;
            decimal rentPrice = 0;

            switch (season)
            {
                case "Summer":
                    car = "Cabrio";
                    break;
                case "Winter":
                    car = "Jeep";
                    break;
            }

            if (budget <= 100)
            {
                classCategory = "Economy class";
            }
            else if (budget > 100 && budget <= 500)
            {
                classCategory = "Compact class";
            }
            else
            {
                classCategory = "Luxury class";
                car = "Jeep";
                rentPrice = budget * 0.9M;
            }

            switch (classCategory)
            {
                case "Economy class":
                    switch (car)
                    {
                        case "Cabrio":
                            rentPrice = budget * 0.35M;
                            break;
                        case "Jeep":
                            rentPrice = budget * 0.65M;
                            break;
                    }
                    break;
                case "Compact class":
                    switch (car)
                    {
                        case "Cabrio":
                            rentPrice = budget * 0.45M;
                            break;
                        case "Jeep":
                            rentPrice = budget * 0.8M;
                            break;
                    }
                    break;
            }

            Console.WriteLine(classCategory);
            Console.WriteLine($"{car} - {rentPrice:f2}");
        }
    }
}
