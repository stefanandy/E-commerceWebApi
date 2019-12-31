namespace TuringEcommerce.Models
{
    public  class Error
    {
        public int Status { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public string Field { get; set; }
        
        
    }
}