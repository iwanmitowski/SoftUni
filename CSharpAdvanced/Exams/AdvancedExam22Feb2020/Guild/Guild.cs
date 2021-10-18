using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roaster;
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roaster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.roaster.Count;

        public void AddPlayer(Player player)
        {
            if (this.Count == this.Capacity)
            {
                throw new InvalidCastException();
            }

            this.roaster.Add(player);
        }

        public bool RemovePlayer(string name)
        {
            var player = this.roaster.FirstOrDefault(x => x.Name == name);

            if (player == null)
            {
                return false;
            }

            this.roaster.Remove(player);

            return true;
        }

        public void PromotePlayer(string name)
        {
            var player = this.roaster.FirstOrDefault(x => x.Name == name);

            if (player != null)
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            var player = this.roaster.FirstOrDefault(x => x.Name == name);

            if (player != null)
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            var players = this.roaster.Where(x => x.Class == @class).ToArray();

            this.roaster.RemoveAll(x => x.Class == @class);

            return players;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.ToString());

            foreach (var player in roaster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }

        public override string ToString()
        {
            return $"Players in the guild: {Name}";
        }
    }
}
