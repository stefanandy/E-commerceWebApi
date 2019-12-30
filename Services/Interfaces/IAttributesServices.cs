using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TuringEcommerce.Models;

namespace TuringEcommerce.Services.Interfaces
{
    public interface IAttributesServices
    {
        public  Task<IEnumerable<Department>> GetAllAttributes();
        public  Task<Department> GetAttributeById(int id);

        public Task<Department> GetAllAtributesValuesByAttributeId(int id);
        public Task<Department> GetAllAttributesOfAProductByProductId(int id);
    }
}