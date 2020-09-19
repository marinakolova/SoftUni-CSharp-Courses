namespace CarDealer.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlRoot("parts")]
    public class ImportPartsIdDto
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }
    }
}
