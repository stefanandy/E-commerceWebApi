namespace TuringEcommerce.Models
{
    public class DepartmentError:Error
    {
        public static Error DEP_01()
        {
            return new Error
            {
                Status = 404,
                Code = "DEP_01",
                Message = "The ID is not a number",
                Field = "department",
            };
        }
        
        public static Error DEP_02()
        {
            return new Error
            {
                Status = 404,
                Code = "DEP_02",
                Message = "Don't exist department with this ID",
                Field = "department",
            };
        }
    }
}