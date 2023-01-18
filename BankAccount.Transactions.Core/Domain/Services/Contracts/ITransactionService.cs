using BankAccount.Shared.Application.RequestModels;
using BankAccount.Transactions.Core.Models.ResponseModels;

namespace BankAccount.Transactions.Core.Domain.Services.Contracts;

public interface ITransactionService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<IReadOnlyCollection<TransactionResponseModel>> GetTransactionsForUserAsync(Guid userId, CancellationToken ct);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<TransactionResponseModel> CreateTransactionAsync(CreateTransactionRequest request, CancellationToken ct);
}