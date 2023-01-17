using BankAccount.Transactions.Core.Domain.Entities;

namespace BankAccount.Transactions.Core.Repositories.Contracts
{
    public interface ITransactionRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IEnumerable<UserTransaction>> GetByUserId(Guid userId, CancellationToken ct);
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<UserTransaction> AddAsync(UserTransaction entity, CancellationToken ct);
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task SaveChangesAsync(CancellationToken ct);
    }
}