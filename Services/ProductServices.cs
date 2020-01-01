using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.PaginatedList;
using TuringEcommerce.Models;
using AspNetCore.PaginatedList;
using PagedList;
using PagedList.EntityFramework;

namespace TuringEcommerce.Services.Interfaces
{
    public class ProductServices:IProductsServices
    {
        private readonly TuringContext _context;
        private readonly ICustomerServices _customerServices;

        public ProductServices(TuringContext context, ICustomerServices customerServices)
        {
            _context = context;
            _customerServices = customerServices;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Product.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Product.FirstOrDefaultAsync(x => x.ProductId == id);
        }

        public async Task<IPagedList<Product>> GetProduct(string queryString, string allWords, int page, int limit, int descriptionLength)
        {
            return await _context.Product.ToPagedListAsync(page, limit);
        }

        public async Task<IPagedList<Product>> GetAllProductsInCategory(int page, int limit, int descriptionLength, int id)
        {
            // TODO: include other parameters
            return await _context.Product.ToPagedListAsync(page, limit);
        }

        public async Task<IPagedList<Product>> GetAllProductsInDepartament(int page, int limit, int descriptionLength, int id)
        {
            return await _context.Product.ToPagedListAsync(page, limit);
        }

        public async Task<IEnumerable> GetProductLocations(int id)
        {
            var categories = from pc in _context.ProductCategory
                join c in _context.Category on pc.CategoryId equals c.CategoryId
                join d in _context.Department on c.DepartmentId equals d.DepartmentId
                where pc.ProductId == id
                select new 
                {
                    CategoryId = c.CategoryId,
                    DepartmentId = c.DepartmentId,
                    CategoryName = c.Name,
                    DepartmentName = d.Name
                };
            return await categories.ToListAsync();
        }

        public async Task<ProductDetail> GetProductDetails(int id)
        {
            var product = await _context.Product
                .Select(p => new ProductDetail
                {
                    ProductId = p.ProductId,
                    Price = p.Price,
                    Description = p.Description,
                    DiscountedPrice = p.DiscountedPrice,
                    Name = p.Name,
                    Image = p.Image,
                    Image2 = p.Image2
                })
                .FirstOrDefaultAsync(d => d.ProductId == id);
            return product;
        }

        public async Task<IEnumerable> GetProductReviews(int id)
        {
            var categories = from pc in _context.Review
                join c in _context.Customer on pc.CustomerId equals c.CustomerId
                where pc.ProductId == id
                select new 
                {
                    Name = c.Name,
                    Rating = pc.Rating,
                    Review = pc.Review1,
                    CreatedOn = pc.CreatedOn.ToString(CultureInfo.InvariantCulture)
                };
            return await categories.ToListAsync();
        }

        public async Task PostProductReview(string customerEmail, int id, string review, short rating)
        {
            var loggedOnCustomer = await _customerServices.GetCustomerByEmail(customerEmail);
            var productReview = new Review
            {
                CustomerId = loggedOnCustomer.CustomerId,
                ProductId = id,
                Review1 = review,
                Rating = rating,
                CreatedOn = DateTime.Now
            };
            _context.Review.Add(productReview);
            await _context.SaveChangesAsync();
        }
    }
}