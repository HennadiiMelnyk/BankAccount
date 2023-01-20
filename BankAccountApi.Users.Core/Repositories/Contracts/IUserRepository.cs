using BankAccountApi.Accounts.Core.Entities;

namespace BankAccountApi.Accounts.Core.Repositories.Contracts
{
    public interface IUserRepository
    {
        /// <summary>
        /// Find By User Id.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<User?> FindByUserIdAsync(Guid userId, CancellationToken ct);
    
        /// <summary>
        /// Find By customer id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<User?> FindByCustomerIdAsync(int customerId, CancellationToken ct);
    
        /// <summary>
        /// Add user.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<User> AddAsync(User entity, CancellationToken ct);
    
        /// <summary>
        /// Save changes in db.
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task SaveChangesAsync(CancellationToken ct);
    }
}