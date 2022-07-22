using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("Product")]
    public class ImportProductDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("buyerId")]
        public int? BuyerId { get; set; }

        [XmlElement("sellerId")]
        public int SellerId { get; set; }
    }
}
