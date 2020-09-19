namespace VaporStore.DataProcessor.Dto.Export
{
	public class GenreDto
	{
		public int Id { get; set; }

		public string Genre { get; set; }

		public GameDto[] Games { get; set; }

		public int TotalPlayers { get; set; }
	}
}
