using Footballers.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models
{
    public class Footballer
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public DateTime ContractStartDate  { get; set; }

        [Required]
        public DateTime ContractEndDate { get; set; }

        [Required]
        public PositionType PositionType { get; set; }

        [Required]
        public BestSkillType BestSkillType { get; set; }

        [Required]
        public int CoachId { get; set; }

        public Coach Coach { get; set; }

        public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; } = new HashSet<TeamFootballer>();
    }
}
