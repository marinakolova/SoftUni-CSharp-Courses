namespace SoftJail.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Message")]
    public class ExportEncryptedMessageDto
    {
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
    }
}
