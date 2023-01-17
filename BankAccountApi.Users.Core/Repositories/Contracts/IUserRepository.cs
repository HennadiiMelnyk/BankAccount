using BankAccountApi.Accounts.Core.Entities;

namespace BankAccountApi.Accounts.Core.Repositories.Contracts;

/// <summary>
/// 
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<User?> FindByUserIdAsync(Guid userId, CancellationToken ct);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="customerId"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<User?> FindByCustomerIdAsync(int customerId, CancellationToken ct);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<User> AddAsync(User entity, CancellationToken ct);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task SaveChangesAsync(CancellationToken ct);
}