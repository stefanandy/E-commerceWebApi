using System.Collections;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using TuringEcommerce.Services.Interfaces;
using Stripe;
using Product = TuringEcommerce.Models.Product;

namespace TuringEcommerce.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController:ControllerBase
    {
        private readonly IProductsServices _service;

        public ProductsController(IProductsServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable> GetAll()
        {
            return await _service.GetAllProducts();
        }

        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Search([FromQuery(Name="query_string")]string query, string allWrods="on", int page=1, int limit=20, int descriptionLength=200)
        {
            var product =await  _service.GetProduct(query,allWrods,page,limit,descriptionLength);
            if (product==null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("{id}"), ActionName("GetId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetSingleProduct(int id)
        {
            var product =  await _service.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("inCategory/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable>> GetAllProductsInCategory(int id, int page=1, int limit=20, int descriptionLength=200)
        {
            var products = await _service.GetAllProductsInCategory(page,limit,descriptionLength,id);
            if (!products.Any())
            {
                return NotFound();
            }

            return Ok(products);
        }
        
        [HttpGet("inDepartment/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable>> GetAllProductsInDepartment(int id, int page=1, int limit=20, int descriptionLength=200)
        {
            var products = await _service.GetAllProductsInDepartament(page,limit,descriptionLength,id);
            if (!products.Any())
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("{id}/reviews")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetReviewsOfProduct(int id)
        {
            var reviews = await _service.GetProductReviews(id);
            if (!reviews.Any())
            {
                return NotFound();
            }

            return Ok(reviews);
        }

        [HttpPost("{id}/reviews")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostReviews(string customerEmail,[FromBody] string review, [FromBody] short rating,int id)
        {
            await _service.PostProductReview( customerEmail, id,  review,  rating);

            return CreatedAtAction("GetId", id);
        }
    }
}