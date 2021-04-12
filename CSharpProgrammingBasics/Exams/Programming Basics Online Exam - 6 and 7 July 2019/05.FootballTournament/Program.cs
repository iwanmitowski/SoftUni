using System;

namespace _05.FootballTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string footballTeam = Console.ReadLine();
            int playedGames = int.Parse(Console.ReadLine());

            double w = 0;
            int d = 0;
            int l = 0;

            int totalPoints = 0;

            for (int i = 0; i < playedGames; i++)
            {
                string result = Console.ReadLine();

                switch (result)
                {
                    case"W":
                            w++;
                        totalPoints += 3;
                        break;
                    case "D":
                        d++;
                        totalPoints += 1;
                        break;
                    default:
                        l++;
                        break;
                }
            }

            if (playedGames==0)
            {
                Console.WriteLine($"{footballTeam} hasn't played any games during this season.");
                
            }
            else
            {
                Console.WriteLine($"{footballTeam} has won {totalPoints} points during this season.");
                Console.WriteLine("Total stats:");
                Console.WriteLine($"## W: {w}");
                Console.WriteLine($"## D: {d}");
                Console.WriteLine($"## L: {l}");
                Console.WriteLine($"Win rate: {w/playedGames*100:f2}%");
            }



        }
    }
}
