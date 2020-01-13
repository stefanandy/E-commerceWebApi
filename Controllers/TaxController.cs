using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TuringEcommerce.Services.Interfaces;

namespace TuringEcommerce.Controllers
{
    [ApiController]
    [Route("tax")]
    public class TaxController:ControllerBase
    {
        private readonly ITaxServices _services;

        public TaxController(ITaxServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetAllTaxes()
        {
            var taxes= await _services.GetAllTaxes();
            if (!taxes.Any())
            {
                return NotFound();
            }

            return Ok(taxes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetById(int id)
        {
            var tax = await _services.GetTaxById(id);
            if (tax == null)
            {
                return NotFound();
            }

            return Ok(tax);
        }

    }
}