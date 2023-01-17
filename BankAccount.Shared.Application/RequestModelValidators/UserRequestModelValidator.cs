using BankAccount.Shared.Application.RequestModels;
using FluentValidation;
namespace BankAccount.Shared.Application.RequestModelValidators;

public class UserRequestModelValidator : AbstractValidator<UserRequestModel>
{
    public UserRequestModelValidator()
    {
        RuleFor(x => x.CustomerId).NotNull().NotEmpty();
    }
}