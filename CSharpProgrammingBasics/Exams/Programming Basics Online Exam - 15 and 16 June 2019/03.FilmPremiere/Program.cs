using System;

namespace _03.FilmPremiere
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            string bundle = Console.ReadLine();
            int tickets = int.Parse(Console.ReadLine());

            double ticketPrice = 0;

            switch (movie)
            {
                case "John Wick":
                    switch (bundle)
                    {
                        case "Drink":
                            ticketPrice = 12;
                            break;
                        case "Popcorn":
                            ticketPrice = 15;
                            break;
                        case "Menu":
                            ticketPrice = 19;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Star Wars":
                    switch (bundle)
                    {
                        case "Drink":
                            ticketPrice = 18;
                            break;
                        case "Popcorn":
                            ticketPrice = 25;
                            break;
                        case "Menu":
                            ticketPrice = 30;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Jumanji":
                    switch (bundle)
                    {
                        case "Drink":
                            ticketPrice = 9;
                            break;
                        case "Popcorn":
                            ticketPrice = 11;
                            break;
                        case "Menu":
                            ticketPrice = 14;
                            break;
                        default:
                            break;
                    }
                    break;
            }

            double bill = ticketPrice * tickets;

            if (movie=="Star Wars"&&tickets>=4)
            {
                bill *= 0.7;
            }
            else if (movie=="Jumanji"&& tickets==2)
            {
                bill *= 0.85;
            }

            Console.WriteLine($"Your bill is {bill:f2} leva.");
        }
    }
}
