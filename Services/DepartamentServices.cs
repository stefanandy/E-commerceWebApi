using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TuringEcommerce.Models;
using TuringEcommerce.Services.Interfaces;

namespace TuringEcommerce.Services
{
    public class DepartamentServices:IDepartmentServices
    {
        private readonly TuringContext _context;

        public DepartamentServices(TuringContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllDepartaments()
        {
            return await _context.Department.AsNoTracking().ToListAsync();
        }

        public async Task<Department> GetDepartamentById(int id)
        {
            return await _context.Department.FirstOrDefaultAsync(x=>x.DepartmentId==id);
        }
    }
}