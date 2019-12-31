using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TuringEcommerce.Models;

namespace TuringEcommerce.Services.Interfaces
{
    public interface IAttributesServices
    {
        public  Task<IEnumerable<Attribute>> GetAllAttributes();
        public  Task<Attribute> GetAttributeById(int id);

        public Task<IEnumerable> GetAllAtributesValuesByAttributeId(int id);
        public Task<IEnumerable> GetAllAttributesOfAProductByProductId(int id);
    }
}