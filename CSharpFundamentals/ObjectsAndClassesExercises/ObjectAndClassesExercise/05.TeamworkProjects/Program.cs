using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _05.TeamworkProjects
{
    class Team
    {
        public Team(string teamName, string owner)
        {
            TeamName = teamName;
            Owner = owner;
            this.Participants = new List<string>() { owner };
        }

        public string TeamName { get; set; }
        public string Owner { get; set; }

        public List<string> Participants { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split("-");

                string creator = tokens[0];
                string teamName = tokens[1];

                if (teams.Any(x => x.TeamName == tokens[1]))
                {
                    Console.WriteLine($"Team { teamName} was already created!");
                }
                else if (teams.Any(x => x.Owner == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                    teams.Add(new Team(teamName, creator));
                }
            }

            string teamInput = Console.ReadLine();

            while (teamInput != "end of assignment")
            {
                string[] tokens = teamInput.Split("->");

                string member = tokens[0];
                string teamName = tokens[1];


                if (!teams.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (teams.Any(x => x.Participants.Any(x=>x == member)))
                {
                    Console.WriteLine($"Member {member} cannot join team {teamName}!");
                }
                else
                {
                    teams.First(x => x.TeamName == teamName).Participants.Add(member);
                }

                teamInput = Console.ReadLine();
            }

            foreach (var team in teams
                .Where(t => t.Participants.Count > 1)
                .OrderByDescending(p => p.Participants.Count())
                .ThenBy(t => t.TeamName))
            {
                Console.WriteLine(team.TeamName);

                Console.WriteLine($"- {team.Owner}");

                team.Participants.Sort();
                foreach (var member in team.Participants)
                {
                    if (member != team.Owner)
                    {
                        Console.WriteLine($"-- {member}");

                    }
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (var team in teams.Where(t => t.Participants.Count == 1).OrderBy(t => t.TeamName))
            {
                Console.WriteLine(team.TeamName);
            }
        }
    }
}
