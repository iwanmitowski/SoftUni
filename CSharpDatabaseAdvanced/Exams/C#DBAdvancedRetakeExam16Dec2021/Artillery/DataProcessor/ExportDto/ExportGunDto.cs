using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Gun")]
    public class ExportGunDto
    {
        [XmlAttribute]
        public string Manufacturer { get; set; }

        [XmlAttribute]
        public string GunType { get; set; }

        [XmlAttribute]
        public int GunWeight { get; set; }

        [XmlAttribute]
        public double BarrelLength { get; set; }

        [XmlAttribute]
        public int Range { get; set; }

        [XmlArray("Countries")]
        public ExportCountryDto[] Countries { get; set; }

    }
}
