using AutoMapper;
using WebApplication2_VMS_TEST.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication2_VMS_TEST.Dto;
using WebApplication2_VMS_TEST.Models;
namespace WebApplication2_VMS_TEST.Helper
{
    public class MappingProfiles : Profile
    {
        private readonly DataContext _context;
        public MappingProfiles()
        {
            
            CreateMap<UserModel, UserDto>();
            CreateMap<UserModel, UserLoginDto>();
            CreateMap<UserDto, UserModel>();

            CreateMap<VehicleModel, VehicleDto>();
            CreateMap<VehicleDto, VehicleModel>();

            CreateMap<DailyActivityDto, DailyActivityModel>();
            CreateMap<DailyActivityModel, DailyActivityDto>();


            CreateMap<DailyActivityModel, TabularViewDto>()
            .ForMember(dest => dest.KmRun, opt => opt.MapFrom(src => 0));

            CreateMap<MaintenanceExpenseModel, MaintenanceExpensesDto>();
            CreateMap<MaintenanceExpensesDto, MaintenanceExpenseModel>();

        }

    }
}
