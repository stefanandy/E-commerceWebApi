using System;

namespace TuringEcommerce.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; }
        public DateTime? ShippedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}