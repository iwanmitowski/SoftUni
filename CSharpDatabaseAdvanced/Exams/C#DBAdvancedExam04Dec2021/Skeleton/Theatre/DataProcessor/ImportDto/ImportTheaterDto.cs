using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Theatre.Data.Models;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTheaterDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(1, 10)]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Director { get; set; }

        public virtual ICollection<ImportTicketDto> Tickets { get; set; }
    }
}
