using System.Net;
using AutoMapper;
using BankAccount.Shared.Application.Exceptions;
using BankAccount.Shared.Application.RequestModels;
using BankAccount.Shared.Application.ResponseModels;
using BankAccountApi.Accounts.Core.Constants;
using BankAccountApi.Accounts.Core.Domain.Services.Contracts;
using BankAccountApi.Accounts.Core.Entities;
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

    public async Task<UserResponseModel> CreateAsync(UserRequestModel userRequestModel, CancellationToken ct)
    {
        var user = await _userRepository.FindByCustomerIdAsync(userRequestModel.CustomerId, ct);

        if (user is not null)
        {
            _logger.LogError($"User with customerId: {userRequestModel.CustomerId} already exist");
            throw new BankAccountException(ErrorMessageConstants.ItemAlreadyExists, HttpStatusCode.Conflict);
            
        }
        
        var userToAdd = _autoMapper.Map<User>(userRequestModel);
        var addedUser = await _userRepository.AddAsync(userToAdd, ct);
        await _userRepository.SaveChangesAsync(ct);
        
        var response = _autoMapper.Map<UserResponseModel>(addedUser);

        return response;
    }
}