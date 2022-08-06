using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class ImportFootballerDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string ContractStartDate { get; set; }

        [Required]
        public string ContractEndDate { get; set; }

        [Required]
        public string PositionType { get; set; }

        [Required]
        public string BestSkillType { get; set; }
    }
}
