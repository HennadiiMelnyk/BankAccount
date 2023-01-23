using AutoMapper;
using BankAccount.Shared.Application.RequestModels;
using BankAccount.Transactions.Core.Domain.Entities;
using BankAccount.Transactions.Core.ResponseModels;

namespace BankAccount.Transactions.Core.Mappings
{
    public class TransactionMappingProfile : Profile
    {
        public TransactionMappingProfile()
        {
            CreateMap<CreateTransactionRequest, UserTransaction>()
                .ForMember(dest => dest.TransactionCreationTime, options => options.MapFrom(src => DateTimeOffset.UtcNow));

            CreateMap<UserTransaction, TransactionResponseModel>()
                .ForMember(
                    dest => dest.Operation, 
                    options => options.MapFrom(src => src.Operation.ToString()));
        }
    }
}
