using BankAccount.Shared.Application.RequestModels;
using FluentValidation;

namespace BankAccount.Shared.Application.RequestModelValidators;

public class TransactionRequestModelValidator : AbstractValidator<CreateTransactionRequest>
{
    public TransactionRequestModelValidator()
    {
        RuleFor(x => x.UserId).NotNull().NotEmpty();
    }
}