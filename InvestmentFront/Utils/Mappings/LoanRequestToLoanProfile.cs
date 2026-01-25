using AutoMapper;
using InvestmentFront.Domain.Entities;
using InvestmentFront.Models;
using System;

namespace InvestmentFront.Utils.Mappings
{
    public class LoanRequestToLoanProfile : Profile
    {
        public LoanRequestToLoanProfile()
        {
            CreateMap<LoanRequest, Loan>()
                .ForMember(dest => dest.LoanRequestID, opt => opt.MapFrom(src => src.LoanRequestID))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Term, opt => opt.MapFrom(src => src.Term))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount));

            CreateMap<Loan, LoanRequest>().ReverseMap();
        }
    }
}

