namespace BankAccount.Transaction.Core.Repositories.Contracts;

public interface ITransactionRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<IEnumerable<Transaction>> GetByUserId(Guid userId, CancellationToken ct);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<Transaction> AddAsync(Transaction entity, CancellationToken ct);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task SaveChangesAsync(CancellationToken ct);
}