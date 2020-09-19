namespace PetStore.Data.Models
{
    using Enums;
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; set; }

        public DateTime PurchaseDate { get; set; }

        public OrderStatus Status { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Pet> Pets { get; set; }

        public ICollection<FoodOrder> Food { get; set; } = new HashSet<FoodOrder>();

        public ICollection<ToyOrder> Toys { get; set; } = new HashSet<ToyOrder>();
    }
}
