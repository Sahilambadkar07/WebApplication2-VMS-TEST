using WebApplication2_VMS_TEST.Data;
using WebApplication2_VMS_TEST.Interfaces;
using WebApplication2_VMS_TEST.Models;

namespace WebApplication2_VMS_TEST.Repository
{
    public class DailyActivityRepository : IDailyActivityRepository
    {
        private readonly DataContext _context;
        public DailyActivityRepository(DataContext context)
        {
            _context = context;
        }

        ICollection<DailyActivityModel> IDailyActivityRepository.GetDailyActivity()
        {
            return _context.DailyActivities.OrderBy(x => x.DailyActivityId).ToList();
        }

        DailyActivityModel IDailyActivityRepository.GetDailyActivityById(int id)
        {
            return _context.DailyActivities.Where(x => x.DailyActivityId == id).FirstOrDefault();
        }
        bool IDailyActivityRepository.DailyActivityExist(int id)
        {
            return _context.DailyActivities.Any(x=>x.DailyActivityId == id);
        }

        public bool CreateDailyActivity(DailyActivityModel dailyactivity)
        {
            _context.DailyActivities.Add(dailyactivity);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public int GetCurrentOdodmeterReading()
        {
            return _context.DailyActivities.OrderByDescending(c=>c.DailyActivityId).Select(x=>x.OdometerReading).FirstOrDefault();
        }

        public decimal GetRemainingFuelAmount()
        {
            return _context.DailyActivities.OrderBy(c=>c.DailyActivityId).Select(x=>x.AmountOfFuel).FirstOrDefault();   
        }
    }
}
