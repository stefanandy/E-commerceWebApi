using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using TuringEcommerce.Models;
using TuringEcommerce.Services;
using TuringEcommerce.Services.Interfaces;

namespace TuringEcommerce.Controllers
{
    [ApiController]
    [Route("attributes")]
    public class AttributesController : ControllerBase
    {
        private readonly IAttributesServices _services;

        public AttributesController(AttributesServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IEnumerable> GetAll()
        {
            return await _services.GetAllAttributes();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Attribute>> GetById(int id)
        {
            var attribute=await _services.GetAttributeById(id);
            if (attribute == null)
            {
                return NotFound();
            }

            return Ok(attribute);
        }

        [HttpGet("values/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable>> GetAllAttributeValuesInAnAttribute(int id)
        {
            var attribute = await _services.GetAllAtributesValuesByAttributeId(id);
            if (!attribute.Any())
            {
                return NotFound();
            }

            return Ok(attribute);
        }
        
        [HttpGet("inProduct/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable>> GetAllAttributesOfAProduct(int id)
        {
            var attribute = await _services.GetAllAttributesOfAProductByProductId(id);
            if (!attribute.Any())
            {
                return NotFound();
            }

            return Ok(attribute);
        }
    }
}