using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.PaginatedList;
using PagedList;
using PagedList.EntityFramework;
using TuringEcommerce.Models;

namespace TuringEcommerce.Services.Interfaces
{
    public interface IProductsServices
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<Product> GetProductById(int id);

        public Task<IPagedList<Product>> GetProduct(string queryString, string allWords, int page, int limit,
            int descriptionLength);
        
        public Task<IPagedList<Product>> GetAllProductsInCategory(int page, int limit, int descriptionLength,
            int id);

        public Task<IPagedList<Product>> GetAllProductsInDepartament(int page, int limit, int descriptionLength,
            int id);

        public Task<IEnumerable> GetProductLocations(int id);
        public Task<ProductDetail> GetProductDetails(int id);
        public Task<IEnumerable> GetProductReviews(int id);

        public Task PostProductReview(string customerEmail, int id, string review, short rating);
    }
}