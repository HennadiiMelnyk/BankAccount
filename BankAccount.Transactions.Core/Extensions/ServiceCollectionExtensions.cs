using BankAccount.Shared.Infrastructure.Database.SqlServer.Extensions;
using BankAccount.Shared.Infrastructure.RabbitMQ.Extensions;
using BankAccount.Transactions.Core.Consumers;
using BankAccount.Transactions.Core.Domain.Services;
using BankAccount.Transactions.Core.Domain.Services.Contracts;
using BankAccount.Transactions.Core.Mappings;
using BankAccount.Transactions.Core.Persistence;
using BankAccount.Transactions.Core.Repositories;
using BankAccount.Transactions.Core.Repositories.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccount.Transactions.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string TransactionDbSettingsSectionName = "TransactionDbSettings";
    
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(TransactionMappingProfile));
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITransactionService, TransactionService>();
        
            services.AddSql<TransactionDbContext>(TransactionDbSettingsSectionName);
        
            services.AddRabbitMqWithConsumer<TransactionConsumer, ConsumerEndpointConfiguration>();

            return services;
        }
    }
}