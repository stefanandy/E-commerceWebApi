using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.PaginatedList;
using TuringEcommerce.Models;

namespace TuringEcommerce.Services.Interfaces
{
    public interface IProductsServices
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<Product> GetProductById();

        public Task<PaginatedList<Product>> GetProduct(string queryString, string allWords, int page, int limit,
            int descriptionLength);
        
        public Task<PaginatedList<Product>> GetAllProductsInCategory(int page, int limit, int descriptionLength,
            int id);

        public Task<PaginatedList<Product>> GetAllProductsInDepartament(int page, int limit, int descriptionLength,
            int id);

        public Task<IEnumerable<Review>> GetProductReviews(int id);

        public Task PostProductReview(int id);
    }
}