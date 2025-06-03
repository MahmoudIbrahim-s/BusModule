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
            CreateMap<Bus, BusDto>().ReverseMap();
            CreateMap<BusAssignment, BusAssignmentDto>().ReverseMap();
            CreateMap<BusRoute, BusRouteDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();


        }
    }

}
