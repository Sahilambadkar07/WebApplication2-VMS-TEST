using WebApplication2_VMS_TEST.Dto;
using WebApplication2_VMS_TEST.Models;

namespace WebApplication2_VMS_TEST.Interfaces
{
    public interface IDashBoardRepository
    {
        int GetCurrentOdodmeterReading(int vehicleid);

        decimal GetRemainingFuelAmount(int vehicleid);

        public decimal Average_Km_Ltr(int vehicleid , DateTime? startdate , DateTime? enddate);

        public decimal FuelExpenses(int vehicleid , DateTime? startdate , DateTime? enddate);

        public decimal MaintExpenses(int vehicleid , DateTime? startdate , DateTime? enddate);

        public decimal TotalExpPerDay(int vehicleid, DateTime? startdate, DateTime? enddate);

        public decimal RsPerKm(int vehicleid, DateTime? startdate, DateTime? enddate);
        
        public decimal KmPerDay(int vehicleid, DateTime? startdate, DateTime? enddate);

        public decimal AvgFuelComPerDay(int vehicleid, DateTime? startdate, DateTime? enddate);

        public decimal AvgMaintPerDay(int vehicleid, DateTime? startdate, DateTime? enddate);

        //IEnumerable<TabularViewDto> GetDailyActivitiesWithDTO();
        //public Task<List<DailyActivityModel>> GetAllAsync(int vehicleid);
    }
}
