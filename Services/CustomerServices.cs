using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TuringEcommerce.Models;
using TuringEcommerce.Services.Interfaces;

namespace TuringEcommerce.Services
{
    public class CustomerServices:ICustomerServices
    {
        private readonly TuringContext _context;

        public CustomerServices(TuringContext context)
        {
            _context = context;
        }

        public async Task<Customer> CreateCustomer(string name, string email, string password)
        {
            //TODO:Password hasher
            throw new System.NotImplementedException();
        }

        public async Task<Customer> UpdateCustomer(string email, string adress1, string adress2, string city, string region, string postalCode,
            string country, int shippingRegionId)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(_customer => _customer.Email == email);

            customer.Address1 = adress1;
            customer.Address2 = adress2;
            customer.City = city;
            customer.Region = region;
            customer.PostalCode = postalCode;
            customer.Country = country;
            customer.ShippingRegionId = shippingRegionId;

            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> UpdateCustomerPassword(string customerEmail, string newEmail, string name, string password, string dayPhone,
            string evePhone, string mobPhone)
        {
            //TODO:Password hasher
            throw new System.NotImplementedException();
        }

        public async Task<Customer> UpdateCreditCard(string email, string creditCard)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(c => c.Email == email);
            customer.CreditCard = creditCard;
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            return await _context.Customer.AsNoTracking().FirstOrDefaultAsync(customer => customer.Email == email);
        }

        public async Task<bool> EmailExist(string email)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(c => c.Email == email);
            if (customer == null)
            {
                return false;
            }

            return true;
        }

        public bool EmailValid(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}