using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccount.Shared.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static T GetSettings<T>(this IServiceCollection services, string sectionName) where T : new()
        {
            using var serviceProvider = services.BuildServiceProvider();
        
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var section = configuration.GetSection(sectionName);
            var settings = new T();
        
            section.Bind(settings);
            
            return settings;
        }
    }
}