using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TuringEcommerce.Models;
using TuringEcommerce.Services.Interfaces;

namespace TuringEcommerce.Services
{
    public class AttributesServices:IAttributesServices
    {
        private readonly TuringContext Context;

        public AttributesServices(TuringContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<Department>> GetAllAttributes()
        {
            return await Context.Department.AsNoTracking().ToListAsync();
        }

        public async Task<Department> GetAttributeById(int id)
        {
            return await Context.Department.FirstOrDefaultAsync(x => x.DepartmentId == id);
        }

        public async Task<Department> GetAllAtributesValuesByAttributeId(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Department> GetAllAttributesOfAProductByProductId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}