namespace TuringEcommerce.Models
{
    public class CartProduct
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int ProductId { get; set; }
        public string Attributes { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string SubTotal { get; set; }
    }
}