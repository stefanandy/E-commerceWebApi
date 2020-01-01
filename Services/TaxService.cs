using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Policy;
using System.Threading.Tasks;
using TuringEcommerce.Models;
using TuringEcommerce.Services.Interfaces;

namespace TuringEcommerce.Services
{
    public class TaxService:ITaxServices
    {

        private readonly TuringContext _context;

        public TaxService(TuringContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tax>> GetAllTaxes()
        {
            return await _context.Tax.AsNoTracking().ToListAsync();
        }

        public async Task<Tax> GetTaxById(int id)
        {
            return await _context.Tax.FirstOrDefaultAsync(t => t.TaxId == id);
        }
    }
}