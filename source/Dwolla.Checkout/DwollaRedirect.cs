using System;
using Newtonsoft.Json;

namespace Dwolla.Checkout
{
    /// <summary>
    /// Upon successful payment, the user will be redirected back to the merchant's website provided by the redirect URL provided during the request. This class represents those parameters to be used in MVC controllers.
    /// </summary>
    public class DwollaRedirect
    {
        public DwollaRedirect()
        {
            //by default, set failed
            this.Status = DwollaStatus.Failed;
            this.Postback = DwollaPostbackStatus.Failure;
        }

        /// <summary>Unique purchase order ID generated by Off-Site Gateway.</summary>
        public string CheckoutId { get; set; }

        /// <summary>Order ID provided during the request.</summary>
        public string OrderId { get; set; }

        /// <summary>Flagged to 'true' if purchase order is for testing purposes only, absent otherwise.</summary>
        public bool Test { get; set; }

        /// <summary>Dwolla transaction ID to identify the successful transaction. If in test mode, the transaction ID has a value of 'null'.</summary>
        public long? Transaction { get; set; }

        /// <summary>If the callback URL provided and the postback response completed successfully, a value of "success" - else, "failure".</summary>
        public DwollaPostbackStatus Postback { get; set; }

        /// <summary>Total amount of the purchase formatted to two decimal places.</summary>
        public decimal Amount { get; set; }

        /// <summary>HMAC-SHA1 hexadecimal hash of the checkoutId and amount ampersand separated using the consumer secret of the application as the hash key.</summary>
        public string Signature { get; set; }

        /// <summary>Date and time in which the funds are to be cleared into the destination account.</summary>
        public string ClearingDate { get; set; }

        /// <summary>Status of the checkout session. Possible values: Completed, and Failed.</summary>
        public DwollaStatus Status { get; set; }

        /// <summary>Error description if there was one.</summary>
        public string Error_Description { get; set; }
    }

    /// <summary>
    /// If the callback URL provided and the postback response completed successfully, a value of "success" - else, "failure".
    /// </summary>
    public enum DwollaPostbackStatus
    {
        Failure,
        Success = 0x1,
    }
}