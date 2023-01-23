using BankAccount.Transactions.Core.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccount.Transactions.Api
{
    public static class TransactionModule
    {
        public const string ModulePath = "transactions";

        public static IServiceCollection AddTransactionsModule(this IServiceCollection services)
        {
            services.AddCore();

            return services;
        }

        public static IApplicationBuilder UseTransactionsModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}