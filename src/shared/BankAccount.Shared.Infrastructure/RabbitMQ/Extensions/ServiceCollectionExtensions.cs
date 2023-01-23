using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccount.Shared.Infrastructure.RabbitMQ.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq();
            });

            return services;
        }
    
        public static IServiceCollection AddRabbitMqWithConsumer<TConsumer, TDefinition>(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer(typeof(TConsumer), typeof(TDefinition));
            
                x.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));
            });

            return services;
        }
    }
}
