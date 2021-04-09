using System;

namespace _07.CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();

            double totalTicketsForTheDay = 0;

            double totalStandard = 0;
            double totalStudent = 0;
            double totalKid = 0;

            while (movie != "Finish")
            {
                int slots = int.Parse(Console.ReadLine());

                double currentSlots = 0;

                while (currentSlots < slots)
                {
                    string ticketType = Console.ReadLine();

                    if (ticketType == "End")
                    {
                        break;
                    }

                    currentSlots++;
                    totalTicketsForTheDay++;

                    switch (ticketType)
                    {
                        case "standard":
                            totalStandard++;
                            break;
                        case "student":
                            totalStudent++;
                            break;
                        case "kid":
                            totalKid++;
                            break;
                    }

                }

                Console.WriteLine($"{movie} - {currentSlots / slots * 100:f2}% full.");

                movie = Console.ReadLine();

            }

            Console.WriteLine($"Total tickets: {totalTicketsForTheDay}");
            Console.WriteLine($"{totalStudent / totalTicketsForTheDay * 100:f2}% student tickets.");
            Console.WriteLine($"{totalStandard / totalTicketsForTheDay * 100:f2}% standard tickets.");
            Console.WriteLine($"{totalKid / totalTicketsForTheDay * 100:f2}% kids tickets.");

        }
    }
}
