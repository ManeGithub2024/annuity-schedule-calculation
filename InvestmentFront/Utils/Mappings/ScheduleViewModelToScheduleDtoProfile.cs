using AutoMapper;
using InvestmentFront.Domain.Entities;
using InvestmentFront.Infrastructure.Services.Model;
using InvestmentFront.Models;
using System;

namespace InvestmentFront.Utils.Mappings
{
    public class ScheduleViewModelToScheduleDtoProfile : Profile
    {
        public ScheduleViewModelToScheduleDtoProfile()
        {
            CreateMap<ScheduleDto, ScheduleViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Payment, opt => opt.MapFrom(src => src.Payment))
                .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.Body))
                .ForMember(dest => dest.Percent, opt => opt.MapFrom(src => src.Percent))
                .ForMember(dest => dest.Left, opt => opt.MapFrom(src => src.Left))
                .ForMember(dest => dest.PaymentDate, opt => opt.MapFrom(src => src.PaymentDate));

            CreateMap<ScheduleViewModel, ScheduleDto>().ReverseMap();
        }
    }
}

