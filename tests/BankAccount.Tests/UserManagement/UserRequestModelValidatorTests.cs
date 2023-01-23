using BankAccountApi.Accounts.Core.RequestModels;
using BankAccountApi.Accounts.Core.RequestModelsValidators;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace BankAccount.Tests.UserManagement
{
    public class UserRequestModelValidatorTests
    {
        private UserRequestModelValidator _requestModelValidator;
    
        [SetUp]
        public void Setup()
        {
            _requestModelValidator = new UserRequestModelValidator();
        }

        [Test]
        public void ShouldReturnErrorWhenInitialCreditIsBelowZeroAndCustomerIdIsNull() 
        {
            var model = new UserRequestModel
            {
                InitialCredit = -1
            };
            var result = _requestModelValidator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.InitialCredit);
            result.ShouldHaveValidationErrorFor(x => x.CustomerId);
        }
    }
}