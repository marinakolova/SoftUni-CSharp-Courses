namespace VaporStore.DataProcessor.Dto.Import
{
    using Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Purchase")]
	public class ImportPurchaseDto
	{
		[XmlAttribute("title")]
		public string Title { get; set; }

		public PurchaseType Type { get; set; }

		[RegularExpression(@"^[\dA-Z]{4}-[\dA-Z]{4}-[\dA-Z]{4}$")]
		public string Key { get; set; }

		public string Card { get; set; }

		public string Date { get; set; }
	}
}