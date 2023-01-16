namespace BankAccountApi.Accounts.Core.Domain.Services.Contracts;

/// <summary>
/// 
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Get user by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task GetUserByIdAsync(Guid id, CancellationToken ct);
}