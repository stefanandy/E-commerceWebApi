using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TuringEcommerce.Models;

namespace TuringEcommerce.Services.Interfaces
{
    public interface ICategoriesServices
    {
        public Task<IEnumerable<Category>> GetAllCategories();
        public Task<Category> GetCategoryById(int id);
        public Task<IEnumerable<CategoryBasic>> GetProductCategoryById(int id);
        public Task<IEnumerable<Category>> GetDepartamentCategorysById(int id);
    }
}