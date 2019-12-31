namespace TuringEcommerce.Models
{
    public class AuthenticationError:Error
    {
        public static Error AUT_01()
        {
            return new Error
            {
                Status = 404,
                Code = "AUT_01",
                Message = " Authorization code is empty.",
                Field = "authentication",
            };
        }

        public static Error AUT_02()
        {
            return new Error
            {
                Status = 404,
                Code = "AUT_02",
                Message = " Access Unauthorized",
                Field = "authentication",
            };
        }
    }
}