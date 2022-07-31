using System.Xml.Serialization;

namespace Theatre.DataProcessor.ExportDto
{
    [XmlType("Actor")]
    public class ExportActorDto
    {
        [XmlAttribute]
        public string FullName { get; set; }

        [XmlAttribute]
        public string MainCharacter { get; set; }
    }
}
