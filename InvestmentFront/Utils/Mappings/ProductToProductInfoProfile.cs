using AutoMapper;
using InvestmentFront.Domain.Entities;
using InvestmentFront.Models;

namespace InvestmentFront.Utils.Mappings
{
    public class ProductToProductInfoProfile : Profile
    {
        public ProductToProductInfoProfile()
        {
            CreateMap<Product, ProductInfo>()
                .ForMember(dest => dest.ProductID, opt => opt.MapFrom(src => src.ProductID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.AnnualRate, opt => opt.MapFrom(src => src.AnnualRate))
                .ForMember(dest => dest.MinAmount, opt => opt.MapFrom(src => src.MinAmount))
                .ForMember(dest => dest.MaxAmount, opt => opt.MapFrom(src => src.MaxAmount))
                .ForMember(dest => dest.MinTerm, opt => opt.MapFrom(src => src.MinTerm))
                .ForMember(dest => dest.MaxTerm, opt => opt.MapFrom(src => src.MaxTerm));

            CreateMap<ProductInfo, Product>().ReverseMap();
        }
    }
}

