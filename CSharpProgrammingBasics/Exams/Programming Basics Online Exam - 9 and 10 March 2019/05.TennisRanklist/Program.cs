using System;

namespace _05.TennisRanklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int tournaments = int.Parse(Console.ReadLine());
            int points = int.Parse(Console.ReadLine());

            double wins = 0;
            double gainedPoints = 0;

            for (int i = 0; i < tournaments; i++)
            {
                string condition = Console.ReadLine();

                if (condition=="W")
                {
                    wins++;
                    gainedPoints += 2000;
                    points += 2000;
                }
                else if (condition=="SF")
                {
                    gainedPoints += 720;
                    points += 720;
                }
                else
                {
                    gainedPoints += 1200;
                    points += 1200;
                }
            }

            gainedPoints /= tournaments;

            Console.WriteLine($"Final points: {points}");
            Console.WriteLine($"Average points: {Math.Floor(gainedPoints)}");
            Console.WriteLine($"{(wins/tournaments)*100:f2}%");
        }
    }
}
