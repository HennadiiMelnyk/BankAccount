using BankAccount.Shared.Application.Extensions;
using BankAccount.Shared.Infrastructure.Database.SqlServer.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccount.Shared.Infrastructure.Database.SqlServer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddSqlServer(this IServiceCollection services, string sectionName)
        {
            var options = services.GetSettings<ConfigurationsSection>(sectionName);
            services.AddSingleton(options);

            return services;
        }
    
    
        public static IServiceCollection AddSqlServer<T>(this IServiceCollection services,
            string sectionName) where T : DbContext
        {
            var options = services.GetSettings<ConfigurationsSection>(sectionName);
            services.AddDbContext<T>(x => x.UseSqlServer(options.DbConnectionString));
        
            using var scope = services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<T>();
            dbContext.Database.Migrate();

            return services;
        }

    }
}