using System.Security.Cryptography;
using AutoMapper;
using BankAccount.Shared.Application.Models;
using BankAccount.Shared.Application.RequestModels;
using BankAccount.Transactions.Core.Domain.Entities;
using BankAccount.Transactions.Core.Domain.Services;
using BankAccount.Transactions.Core.Domain.Services.Contracts;
using BankAccount.Transactions.Core.Mappings;
using BankAccount.Transactions.Core.Repositories.Contracts;
using BankAccount.Transactions.Core.ResponseModels;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Xunit;

namespace BankAccount.Tests.Transactions
{
    public class TransactionServiceTests
    {
        private IMapper _mapper;
        private Mock<ITransactionRepository> _transactionRepositoryMock;

        private ITransactionService _transactionService;


        public TransactionServiceTests()
        {
            var mapperConfiguration = new MapperConfiguration(
                cfg => cfg.AddProfile<TransactionMappingProfile>());
            _mapper = mapperConfiguration.CreateMapper();

            _transactionRepositoryMock = new Mock<ITransactionRepository>();
            _transactionService = new TransactionService(_transactionRepositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task CreateTransactionShouldReturnCreatedTransactionTest()
        {
            // arrange
            var createTransactionRequest = new CreateTransactionRequest()
            {
                UserId = Guid.NewGuid(),
                Amount = 1M,
                Operation = Operation.Deposit
            };
            //id 3720513e-bb8c-4715-94fd-dc9809fba716
            // userid f342fb5b-bdc0-4191-89ed-600bf2bcb0ff
            var transactionToAdd = _mapper.Map<UserTransaction>(createTransactionRequest);
            transactionToAdd.Id = Guid.NewGuid();
            //transactionToAdd.TransactionCreationTime = DateTimeOffset.Now;

            var expectedTransaction = _mapper.Map<TransactionResponseModel>(transactionToAdd);

            _transactionRepositoryMock
                .Setup(x => x.AddAsync(It.IsAny<UserTransaction>(), CancellationToken.None))
                .ReturnsAsync(transactionToAdd);
            _transactionRepositoryMock
                .Setup(x => x.SaveChangesAsync(CancellationToken.None))
                .Returns(Task.CompletedTask);

            // act
            var actual =
                await _transactionService.CreateTransactionAsync(createTransactionRequest, CancellationToken.None);

            // assert
            actual.Should().BeEquivalentTo(expectedTransaction);
            _transactionRepositoryMock.Verify(
                x => x.AddAsync(It.IsAny<UserTransaction>(), CancellationToken.None), Times.Once);
            _transactionRepositoryMock.Verify(
                x => x.SaveChangesAsync(CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task ShouldReturnAllTransactionForSpecifiedUserAsyncTest()
        {
            // arrange
            var userId = new Guid("f342fb5b-bdc0-4191-89ed-600bf2bcb0ff");
            var transaction1 = new UserTransaction()
            {
                Amount = 2,
                Operation = Operation.Deposit,
                Id = Guid.NewGuid(),
                UserId = userId
            };
            var transaction2 = new UserTransaction()
            {
                Amount = 1,
                Operation = Operation.Recipient,
                Id = Guid.NewGuid(),
                UserId = userId
            };
            var transactionsList = new List<UserTransaction>
                { transaction1, transaction2 };

            _transactionRepositoryMock
                .Setup(x => x.GetByUserId(userId, CancellationToken.None))
                .ReturnsAsync(transactionsList);

            var expectedTransactions = transactionsList
                .Select(x => _mapper.Map<TransactionResponseModel>(x));


            // act
            var actual =
                await _transactionService.GetTransactionsForUserAsync(userId, CancellationToken.None);
            
            // assert
            actual.Should().BeEquivalentTo(expectedTransactions);
            actual.Should().NotBeEmpty();
            actual.All(x => x.UserId == userId).Should().BeTrue();
        }
    }
}