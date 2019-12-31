using System;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TuringEcommerce.Models;
using TuringEcommerce.Services.Interfaces;


namespace TuringEcommerce.Controllers
{
    [ApiController]
    [Route("departments")]
    public class DepartmentsControllers : ControllerBase
    {
        private readonly IDepartmentServices _services;

        public DepartmentsControllers(IDepartmentServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IEnumerable> GetAll()
        {
            return await _services.GetAllDepartaments();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Department>> GetById(int id)
        {
            var departament = await _services.GetDepartamentById(id);
            if (departament == null)
            {
                return NotFound(DepartmentError.DEP_02());
            }

            return  Ok(departament);
        }
    }
}