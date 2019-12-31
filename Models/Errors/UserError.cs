namespace TuringEcommerce.Models
{
    public class UserError
    {
        /*USR_01 - Email or Password is invalid.
        USR_02 - The field(s) are/is required.
        USR_03 - The email is invalid.
        USR_04 - The email already exists.
        USR_05 - The email doesn't exist.
        USR_06 - this is an invalid phone number.
        USR_07 - this is too long <FIELD NAME>.
        USR_08 - this is an invalid Credit Card.
        USR_09 - The Shipping Region ID is not number
        */

        public static Error USR_01()
        {
            return new Error
            {
                Status = 404,
                Code = "USR_01",
                Message = "Email or Password is invalid",
                Field = "user",
            };
        }
        public static Error USR_02()
        {
            return new Error
            {
                Status = 404,
                Code = "USR_02",
                Message = "The field(s) are/is required.",
                Field = "user",
            };
        }
        public static Error USR_03()
        {
            return new Error
            {
                Status = 404,
                Code = "USR_03",
                Message = "The email is invalid.",
                Field = "user",
            };
        }
        public static Error USR_04()
        {
            return new Error
            {
                Status = 404,
                Code = "USR_04",
                Message = "The email already exists.",
                Field = "user",
            };
        }
        public static Error USR_05()
        {
            return new Error
            {
                Status = 404,
                Code = "USR_05",
                Message = "The email doesn't exist.",
                Field = "user",
            };
        }
        public static Error USR_06()
        {
            return new Error
            {
                Status = 404,
                Code = "USR_06",
                Message = "this is an invalid phone number.",
                Field = "user",
            };
        }
        public static Error USR_07()
        {
            return new Error
            {
                Status = 404,
                Code = "USR_07",
                Message = "this is too long <FIELD NAME>.",
                Field = "user",
            };
        }
        public static Error USR_08()
        {
            return new Error
            {
                Status = 404,
                Code = "USR_08",
                Message = "this is an invalid Credit Card.",
                Field = "user",
            };
        }
        public static Error USR_09()
        {
            return new Error
            {
                Status = 404,
                Code = "USR_09",
                Message = "The Shipping Region ID is not number",
                Field = "user",
            };
        }
       
    }
}