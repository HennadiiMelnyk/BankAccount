using BankAccount.Shared.Application.RequestModels;
using BankAccount.Transaction.Core.Domain.Services.Contracts;
using BankAccount.Transaction.Core.Models.ResponseModels;
using BankAccount.Transaction.Core.Repositories.Contracts;

namespace BankAccount.Transaction.Core.Domain.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public Task<IReadOnlyCollection<TransactionResponseModel>> GetTransactionsForUserAsync(Guid userId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionResponseModel> CreateTransactionAsync(TransactionRequestModel request, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}