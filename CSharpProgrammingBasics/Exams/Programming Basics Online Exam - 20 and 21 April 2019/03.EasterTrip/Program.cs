using System;

namespace _03.EasterTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string date = Console.ReadLine();
            int nightStands = int.Parse(Console.ReadLine());

            int price = 0;

            switch (date)
            {
                case "21-23":
                    switch (destination)
                    {
                        case "France":
                            price = 30;
                            break;
                        case "Italy":
                            price = 28;
                            break;
                        case "Germany":
                            price = 32;
                            break;
                    }
                    break;
                case "24-27":
                    switch (destination)
                    {
                        case "France":
                            price = 35;
                            break;
                        case "Italy":
                            price = 32;
                            break;
                        case "Germany":
                            price = 37;
                            break;
                    }
                    break;
                case "28-31":
                    switch (destination)
                    {
                        case "France":
                            price = 40;
                            break;
                        case "Italy":
                            price = 39;
                            break;
                        case "Germany":
                            price = 43;
                            break;
                    }
                    break;
                default:
                    break;
            }

            Console.WriteLine($"Easter trip to {destination} : {nightStands*price:f2} leva.");

        }
    }
}
