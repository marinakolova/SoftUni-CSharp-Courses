using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Dlc { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}
