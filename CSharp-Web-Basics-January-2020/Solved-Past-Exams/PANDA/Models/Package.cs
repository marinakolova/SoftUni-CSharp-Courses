using PANDA.Models.Enums;
using System;
using System.Collections.Generic;

namespace PANDA.Models
{
    public class Package
    {
        public Package()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Receipts = new HashSet<Receipt>();
        }

        public string Id { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        public Status Status { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; }

        public string RecipientId { get; set; }

        public User Recipient { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}
