namespace VaporStore.DataProcessor.Dto.Import
{
    using Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    public class ImportCardDto
	{
		[Required]
		[RegularExpression(@"\d{4} \d{4} \d{4} \d{4}")]
		public string Number { get; set; }

        [Required]
        [RegularExpression(@"\d{3}")]
        public string Cvc { get; set; }

		[Required]
		public CardType Type { get; set; }
	}
}