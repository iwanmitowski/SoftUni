using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class ImportPurchaseDto
    {
        [Required]
        public string Type { get; set; }

        [Required]
        [RegularExpression(@"[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}")]
        public string Key { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        [RegularExpression(@"([0-9]{4})\s([0-9]{4})\s([0-9]{4})\s([0-9]{4})")]
        public string Card { get; set; }

        [Required]
        [XmlAttribute("title")]
        public string Title { get; set; }
    }
}
