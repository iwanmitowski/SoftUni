using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();

            decimal price = 0;

            switch (type)
            {
                case "Students":
                    switch (day)
                    {
                        case "Friday":
                            price = 8.45m;
                            break;
                        case "Saturday":
                            price = 9.8m;
                            break;
                        case "Sunday":
                            price = 10.46m;
                            break;
                    }
                    break;
                case "Business":
                    switch (day)
                    {
                        case "Friday":
                            price = 10.9m;
                            break;
                        case "Saturday":
                            price = 15.6m;
                            break;
                        case "Sunday":
                            price = 16m;
                            break;
                    }
                    break;
                case "Regular":
                    switch (day)
                    {
                        case "Friday":
                            price = 15m;
                            break;
                        case "Saturday":
                            price = 20m;
                            break;
                        case "Sunday":
                            price = 22.5m;
                            break;
                    }
                    break;
                default:
                    break;
            }

            decimal total = price * count;

            if (type == "Students" && count >= 30)
            {
                total *= 0.85m;
            }
            else if (type == "Business" && count >= 100)
            {
                total = price * (count - 10);
            }
            else if (type == "Regular" && (count >= 10 && count <= 20))
            {
                total *= 0.95m;
            }

            Console.WriteLine($"Total price: {total:f2}");
        }
    }
}
