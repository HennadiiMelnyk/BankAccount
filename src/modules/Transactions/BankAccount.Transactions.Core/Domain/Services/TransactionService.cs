using AutoMapper;
using BankAccount.Shared.Application.RequestModels;
using BankAccount.Transactions.Core.Domain.Entities;
using BankAccount.Transactions.Core.Domain.Services.Contracts;
using BankAccount.Transactions.Core.Repositories.Contracts;
using BankAccount.Transactions.Core.ResponseModels;

namespace BankAccount.Transactions.Core.Domain.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _autoMapper;

        public TransactionService(ITransactionRepository transactionRepository, IMapper autoMapper)
        {
            _transactionRepository = transactionRepository;
            _autoMapper = autoMapper;
        }

        public async Task<List<TransactionResponseModel>> GetTransactionsForUserAsync(Guid userId, CancellationToken ct)
        {
            var transactions = await _transactionRepository.GetByUserId(userId, ct);

            var transactionResponses = transactions
                .Select(x => _autoMapper.Map<TransactionResponseModel>(x)).ToList();

            return transactionResponses;
        }

        public async Task<TransactionResponseModel> CreateTransactionAsync(CreateTransactionRequest request, CancellationToken ct)
        {
            var transactionToAdd = _autoMapper.Map<UserTransaction>(request);

            var addedTransaction = await _transactionRepository.AddAsync(transactionToAdd, ct);
            await _transactionRepository.SaveChangesAsync(ct);

            var response = _autoMapper.Map<TransactionResponseModel>(addedTransaction);

            return response;
        }
    }
}