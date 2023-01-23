using BankAccountApi.Accounts.Core.RequestModels;
using FluentValidation;

namespace BankAccountApi.Accounts.Core.RequestModelsValidators
{
    public class UserRequestModelValidator : AbstractValidator<UserRequestModel>
    {
        public UserRequestModelValidator()
        {
            RuleFor(x => x.CustomerId).NotNull().NotEmpty().WithMessage("Customer Id cannot be null.");
            RuleFor(x => x.InitialCredit).GreaterThanOrEqualTo(0).WithMessage("Initial credit could not be less than 0.");
        }
    }
}