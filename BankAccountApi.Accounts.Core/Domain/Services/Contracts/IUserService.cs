using BankAccount.Shared.Application.RequestModels;
using BankAccount.Shared.Application.ResponseModels;

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
    Task<UserResponseModel> GetUserByIdAsync(Guid id, CancellationToken ct);

    /// <summary>
    /// Create user.
    /// </summary>
    /// <param name="userRequestModel"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<UserResponseModel> CreateAsync(UserRequestModel userRequestModel, CancellationToken ct);
}