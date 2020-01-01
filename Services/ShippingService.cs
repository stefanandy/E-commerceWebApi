using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using TuringEcommerce.Models;
using TuringEcommerce.Services.Interfaces;

namespace TuringEcommerce.Services
{
    public class ShippingService:IShippingServices
    {
        private readonly TuringContext _context;


        public ShippingService(TuringContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Shipping>> GetAllShipping()
        {
            return await _context.Shipping.AsNoTracking().ToListAsync();
        }

        public async Task<Shipping> GetShippingById(int id)
        {
            return await _context.Shipping.FirstOrDefaultAsync(s => s.ShippingId == id);
        }
    }
}