namespace TuringEcommerce.Models
{
    public class RequestPayment
    {
        public string StripeToken { get; set; }
        public string Email { get; set; }
        public int OrderId { get; set; }
    }
}