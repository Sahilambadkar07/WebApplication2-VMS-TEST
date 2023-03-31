using WebApplication2_VMS_TEST.Models;

namespace WebApplication2_VMS_TEST.Interfaces
{
    public interface IDailyActivityRepository
    {
        ICollection<DailyActivityModel> GetDailyActivity();

        ICollection<DailyActivityModel> GetDailyActivityByVehicleId(int vehicleid);

        DailyActivityModel GetDailyActivityById(int id);
       
        public bool DailyActivityExist(int id);
        
        bool CreateDailyActivity(DailyActivityModel dailyactivity);

        bool Save();
    }
}
