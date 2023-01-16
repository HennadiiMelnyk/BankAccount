using BankAccountApi.Accounts.Core.Domain.Services.Contracts;
using BankAccountApi.Accounts.Core.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace BankAccountApi.Accounts.Core.Domain.Services;

/// <summary>
/// User service.
/// </summary>
public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;
    private readonly IUserRepository _userRepository;


    public UserService(ILogger<UserService> logger, IUserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }

    public async Task GetUserByIdAsync(Guid id, CancellationToken ct)
    {
        var user = await _userRepository.FindByUserIdAsync(id, ct);
        if (user is null)
        {
            throw new ArgumentNullException();
        }
    }
}