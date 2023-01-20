using System.Net;
using BankAccountApi.Accounts.Api.Controllers;
using BankAccountApi.Accounts.Core.Domain.Services.Contracts;
using BankAccountApi.Accounts.Core.Entities;
using BankAccountApi.Accounts.Core.RequestModels;
using BankAccountApi.Accounts.Core.ResponseModels;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Xunit;
using Assert = Xunit.Assert;

namespace BankAccount.Tests.Users
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly UserController _userController;


        public UserControllerTests()
        {
            _userServiceMock = new Mock<IUserService>();
            _userController = new UserController(_userServiceMock.Object);
        }
        
        
        [Fact]
        public async Task GetByIdAsyncShouldReturnOkStatusCode()
        {
            // arrange
            var userId = Guid.NewGuid();
            var userResponse = new UserResponseModel()
            {
                Balance = 600,
                CustomerId = 1,
                Id = userId,
                FirstName = "First",
                LastName = "Last"
            };
            _userServiceMock
                .Setup(x => x.GetUserByIdAsync(userId, CancellationToken.None))
                .ReturnsAsync(userResponse);
            
            // act
            var actual = await _userController.GetUserById(userId, CancellationToken.None);
            var okResult = actual as OkObjectResult;
            
            // assert
            _userServiceMock.Verify(x => x.GetUserByIdAsync(It.IsAny<Guid>(),CancellationToken.None),Times.Once);
            Assert.NotNull(actual);
            Assert.Equal(200, okResult.StatusCode);

        }
    }
}