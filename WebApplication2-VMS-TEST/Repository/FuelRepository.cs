using WebApplication2_VMS_TEST.Interfaces;
using WebApplication2_VMS_TEST.Models;
using WebApplication2_VMS_TEST.Data;

namespace WebApplication2_VMS_TEST.Repository
{
    public class FuelRepository : IFuelRepository
    {
        private readonly DataContext _context;
        public FuelRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<FuelModel> GetFuelActivityByVehicleId(int vehicleid)
        {
            return _context.FuelActivities.OrderBy(c => c.Date).Where(x => x.VehicleId == vehicleid).ToList();
        }

        public bool CreateFuelActivity(FuelModel fuelEntry)
        {
            _context.FuelActivities.Add(fuelEntry);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public FuelModel GetFuelEntryById(int fuelId)
        {
            return _context.FuelActivities.Where(x => x.FueEntrylId == fuelId).FirstOrDefault();
        }

        public decimal GetFuelFilledEntryByDate(DateTime date, int vehicleid)
        {
            return _context.FuelActivities.Where(x => x.Date.Date == date.Date && x.VehicleId == vehicleid).Select(c=>c.FuelFilled).FirstOrDefault();
        }
    }
}
