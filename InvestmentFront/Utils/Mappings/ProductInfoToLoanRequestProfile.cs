using AutoMapper;
using InvestmentFront.Domain.Entities;
using InvestmentFront.Models;
using System;

namespace InvestmentFront.Utils.Mappings
{
    public class ProductInfoToLoanRequestProfile : Profile
    {
        public ProductInfoToLoanRequestProfile()
        {
            CreateMap<ProductInfo, LoanRequest>()
                .ForMember(dest => dest.ProductID, opt => opt.MapFrom(src => src.ProductID))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Term, opt => opt.MapFrom(src => src.Term));

            CreateMap<LoanRequest, ProductInfo>().ReverseMap();
        }
    }
}

