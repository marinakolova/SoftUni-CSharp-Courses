namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    public class UsersAndProductsDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public UsersWithSoldProductsDto[] Users { get; set; }
    }
}
