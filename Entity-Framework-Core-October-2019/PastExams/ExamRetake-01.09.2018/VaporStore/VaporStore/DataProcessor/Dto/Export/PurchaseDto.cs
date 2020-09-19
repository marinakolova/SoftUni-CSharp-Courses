namespace VaporStore.DataProcessor.Dto.Export
{
    using System.Xml.Serialization;

    [XmlType("Purchase")]
	public class PurchaseDto
	{
		public string Card { get; set; }

		public string Cvc { get; set; }

		public string Date { get; set; }

		public PurchaseGameDto Game { get; set; }
	}
}