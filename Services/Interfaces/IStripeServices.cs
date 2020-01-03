using Microsoft.Build.Utilities;
using TuringEcommerce.Models;

namespace TuringEcommerce.Services.Interfaces
{
    public interface IStripeServices
    {
        public void Charge(RequestPayment requestPayment, StripePayment stripe);
    }
}