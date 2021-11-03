using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private readonly HashSet<Player> team;
        private string name;

        public Team(string name)
        {
            Name = name;
            team = new HashSet<Player>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }

        public double Rating => team.Any() ? (int)Math.Round(team.Average(p => p.SkillLevel)) : 0;

        public void AddPlayer(Player player)
        {
            team.Add(player);
        }

        public void RemovePlayer(string name)
        {
            var player = team.FirstOrDefault(x => x.Name == name);

            if (player == null)
            {
                throw new InvalidOperationException($"Player {name} is not in {this.Name} team.");
            }

            team.Remove(player);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
