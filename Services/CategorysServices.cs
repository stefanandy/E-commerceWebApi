using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TuringEcommerce.Models;
using TuringEcommerce.Services.Interfaces;

namespace TuringEcommerce.Services
{
    public class CategorysServices:ICategoriesServices
    {
        private readonly TuringContext _context;

        public CategorysServices(TuringContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Category.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Category.FirstOrDefaultAsync(x => x.CategoryId == id);
        }

        public async Task<IEnumerable<CategoryBasic>> GetProductCategoryById(int id)
        {
            var categories = from productCategory in _context.ProductCategory
                join category in _context.Category
                    on productCategory.CategoryId equals category.CategoryId
                where productCategory.ProductId == id
                select new CategoryBasic
                {
                    CategoryId = category.CategoryId,
                    DepartmentId = category.DepartmentId,
                    Name = category.Name
                };
            return await categories.ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetDepartamentCategorysById(int id)
        {
            var categories = from productCategory in _context.ProductCategory
                join category in _context.Category
                    on productCategory.CategoryId equals category.CategoryId
                where category.DepartmentId == id
                select new Category
                {
                    CategoryId = category.CategoryId,
                    DepartmentId = category.DepartmentId,
                    Name = category.Name,
                    Description = category.Description
                };

            return await categories.ToListAsync();
        }
    }
}