using Microsoft.Build.Utilities;
using TuringEcommerce.Models;
using TuringEcommerce.Services.Interfaces;
using Stripe;

namespace TuringEcommerce.Services
{
    public class StripeServices:IStripeServices
    {
        public void Charge(RequestPayment requestPayment, StripePayment stripe)
        {
            // Set your secret key: remember to change this to your live secret key in production
            // See your keys here: https://dashboard.stripe.com/account/apikeys
            StripeConfiguration.ApiKey = "sk_test_lomdOfxbm7QDgZWvR82UhV6D";

            // Token is created using Checkout or Elements!
            // Get the payment token submitted by the form:
            var token = requestPayment.StripeToken; 

            var options = new ChargeCreateOptions {
                Amount = stripe.Amount,
                Currency = stripe.Currency,
                Description = stripe.Description,
                Source = token,
            };
            var service = new ChargeService();
            Charge charge = service.Create(options);
            
        }
    }
}