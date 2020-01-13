using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TuringEcommerce.Services.Interfaces;

namespace TuringEcommerce.Controllers
{
    [ApiController]
    [Route("shipping")]
    public class ShippingController : ControllerBase
    {
        private readonly IShippingServices _services;

        public ShippingController(IShippingServices services)
        {
            _services = services;
        }

        [HttpGet("regions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable>> GetRegions()
        {
            var regions = await _services.GetAllShipping();
            if (!regions.Any())
            {
                return NotFound();
            }

            return Ok(regions);
        }

        [HttpGet("regions/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetById(int id)
        {
            var region = await _services.GetShippingById(id);
            if (region==null)
            {
                return NotFound();
            }

            return Ok(region);
        }

    }
}