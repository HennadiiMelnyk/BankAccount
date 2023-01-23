using BankAccount.Shared.Application.RequestModels;
using BankAccount.Transactions.Core.Domain.Services.Contracts;
using MassTransit;

namespace BankAccount.Transactions.Core.Consumers
{
    /// <summary>
    /// Consumer.
    /// </summary>
    public class TransactionConsumer : IConsumer<CreateTransactionRequest>
    {
        private readonly ITransactionService _transactionService;

        public TransactionConsumer(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public Task Consume(ConsumeContext<CreateTransactionRequest> context)
        {
            return _transactionService.CreateTransactionAsync(context.Message, default);
        }
    }
}