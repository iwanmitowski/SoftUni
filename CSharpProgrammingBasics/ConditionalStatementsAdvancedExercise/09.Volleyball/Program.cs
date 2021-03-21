using System;

namespace _09.Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string yearType = Console.ReadLine();
            double holidays = int.Parse(Console.ReadLine());
            double weekdends = int.Parse(Console.ReadLine());

            double gamesInSofia = (48 - weekdends)*3/4;
            double gamesInSofiaDuringHoliday = holidays * 2 / 3;
            double totalGames = gamesInSofia + weekdends + gamesInSofiaDuringHoliday;

            if (yearType=="leap")
            {
                totalGames *= 1.15;
            }

            Console.WriteLine(Math.Floor(totalGames));
        }
    }
}
