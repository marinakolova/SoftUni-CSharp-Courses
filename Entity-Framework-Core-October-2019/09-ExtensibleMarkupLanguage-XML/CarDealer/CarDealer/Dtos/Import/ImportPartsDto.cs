namespace CarDealer.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlRoot("parts")]
    public class ImportPartsDto
    {
        [XmlElement("partId")]
        public ImportPartsIdDto[] PartsId { get; set; }
    }
}
