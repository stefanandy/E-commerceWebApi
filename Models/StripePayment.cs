namespace TuringEcommerce.Models
{
    public class StripePayment
    {
        public string StripeToken { get; set; }
        public int OrderId { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
    }
}