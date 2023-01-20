using AutoMapper;
using BankAccount.Shared.Application.RequestModels;
using BankAccountApi.Accounts.Core.Entities;
using BankAccountApi.Accounts.Core.RequestModels;
using BankAccountApi.Accounts.Core.ResponseModels;

namespace BankAccountApi.Accounts.Core.Mappers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserRequestModel, User>()
                .ForMember(dest => dest.Balance, options => options.MapFrom(src => src.InitialCredit))
                .ForMember(
                    dest => dest.Id, 
                    options => options.Ignore());

            CreateMap<User, UserResponseModel>();
        }
    }
}