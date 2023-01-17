using System.Net;
using AutoMapper;
using BankAccount.Shared.Application.RequestModels;
using BankAccount.Shared.Application.ResponseModels;
using BankAccountApi.Accounts.Core.Constants;
using BankAccountApi.Accounts.Core.Domain.Services.Contracts;
using BankAccountApi.Accounts.Core.Exceptions;
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
    private readonly IMapper _autoMapper;


    public UserService(ILogger<UserService> logger, IUserRepository userRepository, IMapper autoMapper)
    {
        _logger = logger;
        _userRepository = userRepository;
        _autoMapper = autoMapper;
    }

    public async Task<UserResponseModel> GetUserByIdAsync(Guid id, CancellationToken ct)
    {
        var user = await _userRepository.FindByUserIdAsync(id, ct);
        if (user is null)
        {
            _logger.LogError($"{ErrorMessageConstants.ItemWasNotFound} result: {HttpStatusCode.NotFound}.");
            throw new BankAccountException(ErrorMessageConstants.ItemWasNotFound, HttpStatusCode.NotFound);
        }
        
        return _autoMapper.Map<UserResponseModel>(user);
    }

    public Task<UserResponseModel> CreateAsync(UserRequestModel userRequestModel, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}