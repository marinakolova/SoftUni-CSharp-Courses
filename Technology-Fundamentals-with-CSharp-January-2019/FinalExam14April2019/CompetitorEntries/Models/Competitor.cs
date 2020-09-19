using System.ComponentModel.DataAnnotations;

namespace CompetitorEntries.Models
{
    public class Competitor
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Team { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
