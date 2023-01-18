using AutoMapper;
using BankAccountApi.Accounts.Core.Domain.Services;
using BankAccountApi.Accounts.Core.Domain.Services.Contracts;
using BankAccountApi.Accounts.Core.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using Moq;

namespace BankAccount.Tests.Users;

public class UserServiceTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<ILogger<UserService>> _loggerMock;
    private readonly IUserService _userService;
    
    
}