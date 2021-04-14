using System;

namespace _01.MovieProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            int tickets = int.Parse(Console.ReadLine());
            double ticketPrice = double.Parse(Console.ReadLine());
            int studioPercent = int.Parse(Console.ReadLine());

            double ticketsPerDay = tickets * ticketPrice;
            double totalIncome = ticketsPerDay * days;
            double tax = totalIncome * studioPercent / 100;

            Console.WriteLine($"The profit from the movie {movie} is {totalIncome-tax:f2} lv.");

        }
    }
}
