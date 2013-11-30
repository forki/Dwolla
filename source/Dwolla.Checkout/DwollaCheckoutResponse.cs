using System;
using Dwolla.Checkout.Validators;
using FluentValidation;
using FluentValidation.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dwolla.Checkout
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
        [JsonConverter(typeof(StringEnumConverter))]
        public DwollaCheckoutResponseResult Result { get; set; }

        /// <summary>The CheckoutId generated by Dwolla used for a URL redirect.</summary>
        public string CheckoutId { get; set; }

        /// <summary>The error message if the Result is a Failure.</summary>
        public string Message { get; set; }

        /// <summary>Returns the URL for the customer's browser to complete the checkout process.</summary>
        public string GetRedirectUrl()
        {
            return DwollaServerCheckoutApi.CheckoutUrl.Replace( "{CheckoutId}", CheckoutId );
        }
    }

    public enum DwollaCheckoutResponseResult
    {
        Success = 0x01,
        Failure
    }
}