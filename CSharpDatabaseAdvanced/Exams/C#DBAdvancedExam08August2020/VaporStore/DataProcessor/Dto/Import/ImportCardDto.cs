using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportCardDto
    {
        [Required]
        [RegularExpression(@"([0-9]{4})\s([0-9]{4})\s([0-9]{4})\s([0-9]{4})")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"([0-9]{3})")]
        public string Cvc { get; set; }

        public string Type { get; set; }
    }
}
