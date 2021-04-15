using System;

namespace _06.BasketballTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string tournament = Console.ReadLine();

           double wins = 0;
           double losses = 0;

            while (tournament != "End of tournaments")
            {
                int n = int.Parse(Console.ReadLine());

                for (int i = 1; i <= n; i++)
                {
                    int desisTeam = int.Parse(Console.ReadLine());
                    int otherTeam = int.Parse(Console.ReadLine());

                    if (desisTeam > otherTeam)
                    {
                        wins++;
                        Console.WriteLine($"Game {i} of tournament {tournament}: win with {desisTeam - otherTeam} points.");
                    }
                    else
                    {
                        losses++;
                        Console.WriteLine($"Game {i} of tournament {tournament}: lost with {otherTeam - desisTeam} points.");
                    }
                }

                tournament = Console.ReadLine();
            }

            double gamesPlayed = wins + losses;

            Console.WriteLine($"{(wins/gamesPlayed)*100:f2}% matches win");
            Console.WriteLine($"{(losses/gamesPlayed)*100:f2}% matches lost");

        }
    }
}
