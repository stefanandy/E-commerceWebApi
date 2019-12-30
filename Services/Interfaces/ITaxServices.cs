using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TuringEcommerce.Models;

namespace TuringEcommerce.Services.Interfaces
{
    public interface ITaxServices
    {
        public Task<IEnumerable<Tax>> GetAllTaxes();
        public Task<Tax> GetTaxById(int id);
    }
}