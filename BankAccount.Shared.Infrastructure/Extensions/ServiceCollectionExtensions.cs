using Microsoft.Extensions.DependencyInjection;

namespace BankAccount.Shared.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services)
        {
            
            services.AddSwaggerGen();

            return services;
        }
    }
}