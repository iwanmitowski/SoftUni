using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Country")]
    public class ExportCountryDto
    {
        [XmlAttribute]
        public string Country { get; set; }

        [XmlAttribute]
        public int ArmySize { get; set; }
    }
}
