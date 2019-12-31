using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TuringEcommerce.Models;

namespace TuringEcommerce.Services.Interfaces
{
    public interface IDepartmentServices
    {
        public Task<IEnumerable<Department>> GetAllDepartaments();

        public Task<Department> GetDepartamentById(int id);
    }
}