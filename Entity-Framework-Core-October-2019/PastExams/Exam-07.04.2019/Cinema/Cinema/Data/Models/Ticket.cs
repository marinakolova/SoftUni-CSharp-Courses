namespace Cinema.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Ticket
    {
        public int Id { get; set; }

        [Range(0.01, 9999999999999999.99)]
        public decimal Price { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int ProjectionId { get; set; }

        public Projection Projection { get; set; }
    }
}
