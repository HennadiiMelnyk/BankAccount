using BankAccount.Transactions.Core.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccountApi.Accounts.Api;

public static class UsersModule
{
    public const string ModulePath = "users";
    
    public static IServiceCollection AddUsersModule(this IServiceCollection services)
    {
        services.AddCore();
            
        return services;
    }

    public static IApplicationBuilder UseUsersModule(this IApplicationBuilder app)
    {
        return app;
    }
}