using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TuringEcommerce.Models;
using TuringEcommerce.Services.Interfaces;

namespace TuringEcommerce.Services
{
    public class DepartamentServices:IDepartmentsCategories
    {
        private readonly TuringContext Context;

        public DepartamentServices(TuringContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<Department>> GetAllDepartaments()
        {
            return await Context.Department.AsNoTracking().ToListAsync();
        }

        public async Task<Department> GetDepartamentById(int id)
        {
            return await Context.Department.FirstOrDefaultAsync(x=>x.DepartmentId==id);
        }
    }
}