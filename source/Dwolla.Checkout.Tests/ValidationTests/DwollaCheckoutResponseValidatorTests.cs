using System.Linq;
using Dwolla.Checkout.Validators;
using FluentAssertions;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace Dwolla.Checkout.Tests.ValidationTests
{
    [TestFixture]
    public class DwollaCheckoutResponseValidatorTests
    {
        private DwollaCheckoutResponseValidator validator;

        [SetUp]
        public void BeforeEachTest()
        {
            this.validator = new DwollaCheckoutResponseValidator();
        }

        [Test]
        public void checkout_result_should_not_pass_validation_if_result_is_a_failure()
        {
            this.validator.ShouldHaveValidationErrorFor( cr => cr.Success, false );
        }

        [Test]
        public void fluent_validate_should_display_checkout_result_message_on_failed_checkout_response()
        {
            var result = this.validator.Validate( new DwollaCheckoutResponse { Success = false, Message = "Invalid total." } );
            result.IsValid.Should().BeFalse();
            result.Errors.First().ErrorMessage.Should().Be( "The checkout request failed. Message from Dwolla's Servers: 'Invalid total.'" );
        }

        [Test]
        public void chekcout_response_should_have_non_null_checkout_id_when_response_result_is_a_success()
        {
            var r = this.validator.TestValidate(new DwollaCheckoutResponse() {Success = true});
            r.Result.IsValid.Should().BeFalse();
        }
    }
}