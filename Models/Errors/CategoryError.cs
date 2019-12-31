namespace TuringEcommerce.Models
{
    public class CategoryError:Error
    {
        public static Error CAT_01()
        {
            return new Error
            {
                Status = 404,
                Code = "CAT_01",
                Message = " Don't exist category with this ID.",
                Field = "category",
            };
        }
    }
}