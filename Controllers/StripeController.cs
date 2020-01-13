using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TuringEcommerce.Models;
using TuringEcommerce.Services;
using TuringEcommerce.Services.Interfaces;

namespace TuringEcommerce.Controllers
{
    [ApiController]
    [Route("stripe")]
    public class StripeController:ControllerBase
    {
        private readonly IStripeServices _services;

        public StripeController(IStripeServices services)
        {
            _services = services;
        }

        [HttpGet("charge")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Charge([FromForm]string stripeToken, [FromForm]string email, [FromForm]int orderId, [FromForm]string description, [FromForm] int amount, string currency="usd")
        {
            var service = new StripePayment
            {
                OrderId = orderId,
                StripeToken = stripeToken,
                Amount = amount,
                Description = description,
                Currency = currency
            };

           var payment= new RequestPayment
            {
                Email = email,
                OrderId = orderId,
                StripeToken = stripeToken
            };
            
            _services.Charge(payment,service);
            
            return Ok();
        }
    }
}