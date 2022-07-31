using System.Xml.Serialization;
using Theatre.Data.Models.Enums;

namespace Theatre.DataProcessor.ExportDto
{
    [XmlType("Play")]
    public class ExportPlayDto
    {
        [XmlAttribute]
        public string Title { get; set; }

        [XmlAttribute]
        public string Duration { get; set; }

        [XmlAttribute]
        public string Rating { get; set; }

        [XmlAttribute]
        public Genre Genre { get; set; }

        [XmlArray("Actors")]
        public virtual ExportActorDto[] Actors { get; set; }
    }
}
