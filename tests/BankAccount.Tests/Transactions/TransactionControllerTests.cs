using BankAccount.Transactions.Api.Controllers;
using BankAccount.Transactions.Core.Domain.Services.Contracts;
using BankAccount.Transactions.Core.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BankAccount.Tests.Transactions
{
    public class TransactionControllerTests
    {
        private readonly Mock<ITransactionService> _transactionServiceMock;
        private readonly TransactionController _transactionController;

        public TransactionControllerTests()
        {
            _transactionServiceMock = new Mock<ITransactionService>();
            _transactionController = new TransactionController(_transactionServiceMock.Object);
        }

        [Fact]
        public async Task ShouldReturnTransactionForUserTest()
        {
            // arrange
            var userId = new Guid("f342fb5b-bdc0-4191-89ed-600bf2bcb0ff");
        
            var transaction1 = new TransactionResponseModel()
            {
                Amount = 2,
                Operation = "Deposit",
                Id = Guid.NewGuid(),
                UserId = userId
            };
            var transaction2 = new TransactionResponseModel()
            {
                Amount = 1,
                Operation = "Recipient",
                Id = Guid.NewGuid(),
                UserId = userId
            };
            var transactionsList = new List<TransactionResponseModel>
                { transaction1, transaction2 };
            _transactionServiceMock
                .Setup(x => x.GetTransactionsForUserAsync(userId, CancellationToken.None))
                .ReturnsAsync(transactionsList);
            // act
            var actual = await _transactionController.GetUserTransaction(userId, CancellationToken.None);
            var okResult = actual as OkObjectResult;

            // assert
            _transactionServiceMock.Verify(x=> x.GetTransactionsForUserAsync(It.IsAny<Guid>(),CancellationToken.None),Times.Once);
        
            Assert.NotNull(actual);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}