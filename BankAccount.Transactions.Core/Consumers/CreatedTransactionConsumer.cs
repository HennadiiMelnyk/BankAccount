using BankAccount.Shared.Application.RequestModels;
using BankAccount.Transactions.Core.Domain.Services.Contracts;
using MassTransit;

namespace BankAccount.Transactions.Core.Consumers;

public class CreatedTransactionConsumer : IConsumer<CreateTransactionRequest>
{
    private readonly ITransactionService _transactionService;

    public CreatedTransactionConsumer(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public Task Consume(ConsumeContext<CreateTransactionRequest> context)
    {
        return _transactionService.CreateTransactionAsync(context.Message, default);
    }
}