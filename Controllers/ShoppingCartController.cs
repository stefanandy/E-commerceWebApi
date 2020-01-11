using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using TuringEcommerce.Services.Interfaces;

namespace TuringEcommerce.Controllers
{

    [ApiController]
    [Route("shoppingcart")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartServices _services;
        private readonly IProductsServices _productsServices;

        public ShoppingCartController(IShoppingCartServices services, IProductsServices productsServices)
        {
            _services = services;
            _productsServices = productsServices;
        }


        [HttpGet("generateUniqueId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GenerateCartId()
        {
            var cart = new
            {
                cart_id = Guid
                    .NewGuid()
                    .ToString()
                    .Replace("-", "")
                    .Substring(0, 15)
            };
            return Ok(await Task.FromResult(cart));
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Add(string cart_id, int product_id, string attributes, int quantity)
        {
            await _services.AddItem(cart_id, product_id, attributes);

            return CreatedAtAction("GetId", cart_id);
        }

        [HttpGet("{id}"),ActionName("GetId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable>> GetListOfProductsInAShoppingCart(string id)
        { 
            var cartProducts = await _services.GetShoppingCartById(id);
            if (!cartProducts.Any())
            {
                return NotFound();
            }

            return Ok(cartProducts);
        }

        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateCartItemQuantity(int id,[FromForm]int quantity)
        {
            await _services.UpdateItems(id, quantity);
            var product = await _productsServices.GetProductById(id);
            var cartId = await _services.GetCartIdByItem(id);
            return Ok(
                new{ 
                    id,
                    cartId,
                    product.ProductId,
                    quantity,
            } );
        }

        [HttpDelete("empty/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> EmptyShoppingCart(string id)
        {
            await _services.EmptyCart(id);
            var shoppingCart = await _services.GetShoppingCartById(id);
            if (!shoppingCart.Any())
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("removeProduct/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> RemoveItemFromShippingCart(int id)
        {
            await _services.RemoveItem(id);
            return Ok();
        }



    }
}