using BankAccount.Shared.Application.RequestModels;
using BankAccount.Transactions.Core.ResponseModels;

namespace BankAccount.Transactions.Core.Domain.Services.Contracts;

public interface ITransactionService
{
    /// <summary>
    /// Get Transaction for user.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<List<TransactionResponseModel>> GetTransactionsForUserAsync(Guid userId, CancellationToken ct);
    
    /// <summary>
    /// Create transaction.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<TransactionResponseModel> CreateTransactionAsync(CreateTransactionRequest request, CancellationToken ct);
}