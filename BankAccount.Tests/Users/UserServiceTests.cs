using AutoMapper;
using BankAccount.Shared.Application.Exceptions;
using BankAccountApi.Accounts.Core.Domain.Services;
using BankAccountApi.Accounts.Core.Domain.Services.Contracts;
using BankAccountApi.Accounts.Core.Entities;
using BankAccountApi.Accounts.Core.Mappers;
using BankAccountApi.Accounts.Core.Repositories.Contracts;
using BankAccountApi.Accounts.Core.RequestModels;
using BankAccountApi.Accounts.Core.ResponseModels;
using FluentAssertions;
using MassTransit;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Xunit;
using Assert = Xunit.Assert;

namespace BankAccount.Tests.Users
{
    public class UserServiceTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<ILogger<UserService>> _loggerMock;
        private readonly IUserService _userService;
        private readonly Mock<IPublishEndpoint> _publishEndpointMock;
        

        public UserServiceTests()
        {
            var mapperConfiguration = new MapperConfiguration(
                cfg => cfg.AddProfile<UserMappingProfile>());
            _mapper = mapperConfiguration.CreateMapper();

            _loggerMock = new Mock<ILogger<UserService>>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _publishEndpointMock = new Mock<IPublishEndpoint>();
            _userService = new UserService(
                _loggerMock.Object, 
                _userRepositoryMock.Object, 
                _mapper,
                 _publishEndpointMock.Object); 
        }
        
        
        [Fact]
        public async Task GetByIdAsyncShouldThrowExceptionIfUserNotExists()
        {
            // arrange
            var userId = Guid.NewGuid();
            _userRepositoryMock
                .Setup(x => x.FindByUserIdAsync(userId, CancellationToken.None))
                .ReturnsAsync((User?) null);

            // act assert

            await Assert.ThrowsAsync<BankAccountException>(() =>
                 _userService.GetUserByIdAsync(userId, CancellationToken.None));
        }

        [Fact]
        public async Task CreateAsyncShouldReturnExceptionIfUserWithThisCustomerIdAlreadyExists()
        {
            // arrange
            var createUserRequest = new UserRequestModel()
            {
                CustomerId = 1,
                FirstName = "First",
                InitialCredit = -1,
                LastName = "last"
            };


            _userRepositoryMock
                .Setup(x => x.FindByCustomerIdAsync(createUserRequest.CustomerId, CancellationToken.None))
                .ReturnsAsync(new User());
            
            
            // act assert

            await Assert.ThrowsAsync<BankAccountException>(() =>
                _userService.CreateAsync(createUserRequest, CancellationToken.None));
        }
        
        [Fact]
        public async Task GetByIdAsyncShouldReturnUserResponse()
        {
            // arrange
            var userId = Guid.NewGuid();
            var user = new User()
            {
                Balance = 1,
                CustomerId = 1,
                FirstName = "First",
                LastName = "Last",
                Id = Guid.NewGuid()
            };
            _userRepositoryMock
                .Setup(x => x.FindByUserIdAsync(userId, CancellationToken.None))
                .ReturnsAsync(user);
            var expectedResponse = _mapper.Map<UserResponseModel>(user);
        
            // act
            var actual = await _userService.GetUserByIdAsync(userId, CancellationToken.None);

            // assert
            _userRepositoryMock
                .Verify(x => x.FindByUserIdAsync(userId, CancellationToken.None), Times.Once);
            actual.Should().BeEquivalentTo(expectedResponse);
        }
    }
}