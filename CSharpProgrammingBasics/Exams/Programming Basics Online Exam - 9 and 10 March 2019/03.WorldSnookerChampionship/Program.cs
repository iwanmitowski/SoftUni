using System;

namespace _03.WorldSnookerChampionship
{
    class Program
    {
        static void Main(string[] args)
        {
            string final = Console.ReadLine();
            string ticketType = Console.ReadLine();
            int tickets = int.Parse(Console.ReadLine());
            string photo = Console.ReadLine();

            double ticketPrice = 0;

            switch (final)
            {
                case "Quarter final":
                    switch (ticketType)
                    {
                        case "Standard":
                            ticketPrice = 55.5;
                            break;
                        case "Premium":
                            ticketPrice = 105.2;
                            break;
                        case "VIP":
                            ticketPrice = 118.90;
                            break;
                    }
                    break;
                case "Semi final":
                    switch (ticketType)
                    {
                        case "Standard":
                            ticketPrice = 75.88;
                            break;
                        case "Premium":
                            ticketPrice = 125.22;
                            break;
                        case "VIP":
                            ticketPrice = 300.40;
                            break;
                    }
                    break;
                case "Final":
                    switch (ticketType)
                    {
                        case "Standard":
                            ticketPrice = 110.10;
                            break;
                        case "Premium":
                            ticketPrice = 160.66;
                            break;
                        case "VIP":
                            ticketPrice = 400;
                            break;
                    }
                    break;
            }

            double totalPrice = ticketPrice * tickets;

            if (totalPrice>4000)
            {
                totalPrice *= 0.75;
                photo = "N";
            }
            else if (totalPrice>2500)
            {
                totalPrice *= 0.9;
            }

            if (photo=="Y")
            {
                totalPrice += tickets*40;
            }

            Console.WriteLine($"{totalPrice:f2}");

        }
    }
}
