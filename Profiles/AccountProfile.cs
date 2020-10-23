using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountLibrary.API.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Entities.AccountTransaction, Models.Transaction>()
                .ForMember(
                    dest => dest.currentBalance,
                    opt => opt.MapFrom(src => $"{src.Available_balance}"))
                .ForMember(
                    dest => dest.transactionAmount,
                    opt => opt.MapFrom(src => $"{src.Transaction_Amount}"))
                 .ForMember(
                    dest => dest.transactionType,
                    opt => opt.MapFrom(src => $"{src.Transaction_Type}"))
                 .ForMember(
                    dest => dest.transactionName,
                    opt => opt.MapFrom(src => $"{src.transaction_towards}"))

                 .ForMember(
                    dest => dest.transactionDate,
             // opt => opt.MapFrom(src => $"{src.Transaction_Date}"));
             opt => opt.ResolveUsing(o => MapTransactionDate(o.Transaction_Date)));
        }

        private DateTime MapTransactionDate(string transaction_Date)
        {
            return Convert.ToDateTime(transaction_Date);
        }
    }
}
