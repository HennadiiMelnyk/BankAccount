using BankAccount.Shared.Application.RequestModels;
using BankAccount.Transaction.Core.Models.ResponseModels;

namespace BankAccount.Transaction.Core.Domain.Services.Contracts;

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
    Task<TransactionResponseModel> CreateTransactionAsync(TransactionRequestModel request, CancellationToken ct);
}