using AutoMapper;
using BusModule.DTOs;
using BusModule.Models;
using BusModule.Services;

namespace BusModule.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BusType, BusTypeDto>().ReverseMap();
            CreateMap<BusCategory, BusCategoryDto>().ReverseMap();
            CreateMap<Bus, BusDto>().ReverseMap();

        }
    }

}
