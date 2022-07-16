using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
            this.HomeGames = new HashSet<Game>();
            this.AwayGames = new HashSet<Game>();
        }

        public int TeamId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(255)")]
        public string LogoUrl { get; set; }

        [Required]
        [Column(TypeName = "CHAR(3)")]
        public string Initials { get; set; }

        public decimal Budget { get; set; }

        public int TownId { get; set; }

        public Town Town { get; set; }

        public int PrimaryKitColorId { get; set; }

        public Color PrimaryKitColor { get; set; }

        public int SecondaryKitColorId { get; set; }

        public Color SecondaryKitColor { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        //Виж FootballBettingContext за допълнителна настройка
        [InverseProperty(nameof(Game.HomeTeam))]
        public virtual ICollection<Game> HomeGames { get; set; }

        [InverseProperty(nameof(Game.AwayTeam))]
        public virtual ICollection<Game> AwayGames { get; set; }
    }
}
