using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TuringEcommerce.Models;

namespace TuringEcommerce.Services.Interfaces
{
    public interface IShippingServices
    {
        public Task<IEnumerable<Shipping>> GetAllShipping();
        public Task<Shipping> GetShippingById(int id);
    }
}