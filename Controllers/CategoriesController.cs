using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TuringEcommerce.Models;
using TuringEcommerce.Services.Interfaces;

namespace TuringEcommerce.Controllers
{

    [ApiController]
    [Route("categories")]
    public class CategoriesController:ControllerBase
    {
        private readonly ICategoriesServices _services;

        public CategoriesController(ICategoriesServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IEnumerable> GetAll()
        {
            return await _services.GetAllCategories();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var category = await _services.GetCategoryById(id);
            if (category == null)
            {
                return NotFound(CategoryError.CAT_01());
            }

            return Ok(category);
        }
        
        [HttpGet("inProduct/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable>> GetProductCategoryById(int id)
        {
            var category = await _services.GetProductCategoryById(id);
            if (!category.Any())
            {
                return NotFound(CategoryError.CAT_01());
            }

            return Ok(category);
        }
        
        [HttpGet("inDepartment/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable>> GetAllCategoriesInDepartmentById(int id)
        {
            var category = await _services.GetDepartamentCategorysById(id);
            if (!category.Any())
            {
                return NotFound(CategoryError.CAT_01());
            }

            return Ok(category);
        }

    }
}