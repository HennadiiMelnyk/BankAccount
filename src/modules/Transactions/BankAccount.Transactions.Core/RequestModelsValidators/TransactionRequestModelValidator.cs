using BankAccount.Shared.Application.RequestModels;
using FluentValidation;

namespace BankAccount.Transactions.Core.RequestModelsValidators
{
    public class TransactionRequestModelValidator : AbstractValidator<CreateTransactionRequest>
    {
        public TransactionRequestModelValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty();
        }
    }
}