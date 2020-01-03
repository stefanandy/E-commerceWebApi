using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TuringEcommerce.Models;
using TuringEcommerce.Services.Interfaces;

namespace TuringEcommerce.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrdersController:ControllerBase
    {
        private readonly IOrdersServices _services;

        public OrdersController(IOrdersServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<ActionResult> Post(int customerId,string cartId, int shippingId, int taxId)
        {
            var orderId= await _services.PostOrder(customerId, cartId, shippingId, taxId);
            return CreatedAtAction("GetId", orderId);
        }

        [HttpGet("{id}"), ActionName("GetId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetOrderById(int id)
        {
            var order= await _services.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpGet("/inCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetCsutomersOrders(int id)
        {
            var orders = await _services.GetOrdersByCustomerId(id);
            if (!orders.Any())
            {
                return NotFound();
            }

            return Ok(orders);
        }

    }
}