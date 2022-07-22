using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Product")]
    public class ProductExportDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
        
        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
