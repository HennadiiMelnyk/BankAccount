using BankAccount.Shared.Infrastructure.Database.SqlServer.Extensions;
using BankAccountApi.Accounts.Core.Domain.Services;
using BankAccountApi.Accounts.Core.Domain.Services.Contracts;
using BankAccountApi.Accounts.Core.Mappers;
using BankAccountApi.Accounts.Core.Persistence;
using BankAccountApi.Accounts.Core.Repositories;
using BankAccountApi.Accounts.Core.Repositories.Contracts;

using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccountApi.Accounts.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string UserDbSettingsSectionName = "UserDbSettings";

        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserMappingProfile));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
        
        
            services.AddSql<UsersDbContext>(UserDbSettingsSectionName);

            services.AddFluentValidation(fv =>
            {
                fv.ImplicitlyValidateChildProperties = true;
                fv.ImplicitlyValidateRootCollectionElements = true;
                fv.RegisterValidatorsFromAssemblyContaining<UsersDbContext>();
                fv.DisableDataAnnotationsValidation = true;
            });


            return services;
        }
    }
}