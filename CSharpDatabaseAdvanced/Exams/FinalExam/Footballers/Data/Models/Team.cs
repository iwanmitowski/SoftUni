using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.Data.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9\s\.-]+")]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Nationality { get; set; }

        [Required]
        public int Trophies { get; set; }

        public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; } = new HashSet<TeamFootballer>();

    }
}
