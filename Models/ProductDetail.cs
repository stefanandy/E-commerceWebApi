namespace TuringEcommerce.Models
{
    public class ProductDetail
    {
        public  int ProductId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Image2 { get; set; }
    }
}