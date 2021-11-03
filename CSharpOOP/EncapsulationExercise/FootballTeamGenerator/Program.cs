using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var teams = new HashSet<Team>();

            while (input != "END")
            {
                try
                {

                    string[] tokens = input.Split(";");

                    string command = tokens[0];
                    string teamName = tokens[1];

                    var team = teams.FirstOrDefault(x => x.Name == teamName);

                    if (command != "Team")
                    {
                        if (team == null)
                        {
                            throw new InvalidOperationException($"Team {teamName} does not exist.");
                        }
                    }

                    switch (command)
                    {
                        case "Team":
                            teams.Add(new Team(teamName));
                            break;
                        case "Add":
                            team.AddPlayer(new Player(tokens[2],
                                int.Parse(tokens[3]),
                                int.Parse(tokens[4]),
                                int.Parse(tokens[5]),
                                int.Parse(tokens[6]),
                                int.Parse(tokens[7])));

                            break;
                        case "Remove":
                            team.RemovePlayer(tokens[2]);
                            break;
                        case "Rating":
                            Console.WriteLine(team);
                            break;
                    }

                    input = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    input = Console.ReadLine();
                }
            }
        }
    }
}
