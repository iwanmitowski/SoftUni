using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class ImportCastDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string FullName { get; set; }

        [Required]
        public bool IsMainCharacter { get; set; }

        [RegularExpression(@"\+44-[0-9]{2}-[0-9]{3}-[0-9]{4}")]
        public string PhoneNumber { get; set; }

        [Required]
        public int PlayId { get; set; }
    }
}
