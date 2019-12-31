namespace TuringEcommerce.Models
{
    public class PaginationError:Error
    {
        public static Error PAG_01()
        {
            return new Error
            {
                Status = 404,
                Code = "PAG_01",
                Message = "The order is not matched 'filed,(DESC|ASC)'",
                Field = "pagination",
            };
        }
        
        public static Error PAG_02()
        {
            return new Error
            {
                Status = 404,
                Code = "PAG_02",
                Message = "The filed of order is not allow sorting'",
                Field = "pagination",
            };
        }
        
    }
}