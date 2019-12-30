using System.Threading.Tasks;
using Microsoft.Build.Utilities;
using TuringEcommerce.Models;

namespace TuringEcommerce.Services.Interfaces
{
    public interface ICustomerServices
    {
        public Task<Customer> CreateCustomer(string name, string email, string password);

        public Task<Customer> UpdateCustomer(string email, string adress1, string adress2, string city, string regions,
            string postalCode, string country, int shippingRegionId);

        public Task<Customer> UpdateCustomerPassword(string customerEmail, string newEmail, string name,
            string password, string dayPhone, string evePhone, string mobPhone);

        public Task<Customer> UpdateCreditCard(string email, string creditCard);

        public Task<Customer> GetCustomerByEmail(string email);

        public Task<bool> EmailExist(string email);
        public bool EmailValid(string email);
    }
}