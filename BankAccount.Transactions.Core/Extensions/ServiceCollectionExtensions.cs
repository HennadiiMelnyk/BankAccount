using BankAccount.Transactions.Core.Domain.Services;
using BankAccount.Transactions.Core.Domain.Services.Contracts;
using BankAccount.Transactions.Core.Repositories;
using BankAccount.Transactions.Core.Repositories.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccount.Transactions.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(TransactionMappingProfile));
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<ITransactionService, TransactionService>();

        return services;
    }
}