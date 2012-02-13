using Dwolla.OffSiteGateway.Validators;
using FluentValidation.Attributes;

namespace Dwolla.OffSiteGateway
{
    [Validator( typeof( DwollaCheckoutResponseValidator ) )]
    public class DwollaCheckoutResponse
    {
        public DwollaCheckoutResponse()
        {
            //by default, fail.
            Result = DwollaCheckoutResponseResult.Failure;
        }

        /// <summary>The result of the checkout request.</summary>
        public DwollaCheckoutResponseResult Result { get; set; }

        /// <summary>The CheckoutId generated by Dwolla used for a URL redirect.</summary>
        public string CheckoutId { get; set; }

        /// <summary>The error message if the Result is a Failure.</summary>
        public string Message { get; set; }
    }

    public enum DwollaCheckoutResponseResult
    {
        Success = 0x01,
        Failure
    }
}