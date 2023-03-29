using AutoMapper;
using WebApplication2_VMS_TEST.Dto;
using WebApplication2_VMS_TEST.Models;
namespace WebApplication2_VMS_TEST.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserModel, UserDto>();
            CreateMap<UserDto, UserModel>();

            CreateMap<VehicleModel, VehicleDto>();
            CreateMap<VehicleDto,VehicleModel>();

            CreateMap <DailyActivityDto,DailyActivityModel>();
            CreateMap <DailyActivityModel, DailyActivityDto>();
            
            CreateMap <MaintenanceExpenseModel, MaintenanceExpensesDto>();
            CreateMap <MaintenanceExpensesDto, MaintenanceExpenseModel>();

        }
    }
} 
