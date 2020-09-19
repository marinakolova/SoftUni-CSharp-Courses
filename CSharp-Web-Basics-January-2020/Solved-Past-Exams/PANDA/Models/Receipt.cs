using System;

namespace PANDA.Models
{
    public class Receipt
    {
        public Receipt()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        public string RecipientId { get; set; }

        public User Recipient { get; set; }

        public string PackageId { get; set; }

        public Package Package { get; set; }
    }
}
