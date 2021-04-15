using System;

namespace _03.Gymnastics
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string tool = Console.ReadLine();

            double points = 0;

            switch (country)
            {
                case "Russia":
                    switch (tool)
                    {
                        case "ribbon":
                            points = 9.1 + 9.4;
                            break;
                        case "hoop":
                            points = 9.3 + 9.8;
                            break;
                        case "rope":
                            points = 9.6 + 9;
                            break;
                    }
                    break;
                case "Bulgaria":
                    switch (tool)
                    {
                        case "ribbon":
                            points = 9.6 + 9.4;
                            break;
                        case "hoop":
                            points = 9.55 + 9.750;
                            break;
                        case "rope":
                            points = 9.5 + 9.4;
                            break;
                    }
                    break;
                case "Italy":
                    switch (tool)
                    {
                        case "ribbon":
                            points = 9.2 + 9.5;
                            break;
                        case "hoop":
                            points = 9.45 + 9.35;
                            break;
                        case "rope":
                            points = 9.7 + 9.15;
                            break;
                    }
                    break;

                default:
                    break;
            }
            double percent = ((20 - points)/20)*100;

            Console.WriteLine($"The team of {country} get {points:f3} on {tool}.");
            Console.WriteLine($"{percent:f2}%");

        }
    }
}
