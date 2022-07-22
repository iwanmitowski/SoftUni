using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("CategoryProduct")]
    public class ImportCategoryProductDto
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
    }
}
