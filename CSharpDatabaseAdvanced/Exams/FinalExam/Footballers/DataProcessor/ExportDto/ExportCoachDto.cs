using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Coach")]
    public class ExportCoachDto
    {
        public string CoachName { get; set; }

        [XmlArray("Footballers")]
        public ExportFootballersDto[] Footballers { get; set; }

        [XmlAttribute]
        public int FootballersCount { get; set; }
    }
}
