using WebApplication2_VMS_TEST.Data;
using WebApplication2_VMS_TEST.Models;
using WebApplication2_VMS_TEST.Interfaces;

namespace WebApplication2_VMS_TEST.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly DataContext _context;
        public VehicleRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateVehicle(VehicleModel vehicle)
        {
            _context.Vehicles.Add(vehicle);
            return Save();
        }

        public ICollection<VehicleModel> GetVehicle()
        {
            return _context.Vehicles.OrderBy(x => x.VehicleId).ToList();
        }

        public VehicleModel GetVehicleById(int id)
        {
            return _context.Vehicles.Where(x => x.VehicleId == id).FirstOrDefault();
        }

        public ICollection<VehicleModel> GetVehicleByUserId(int userid)
        {
            return _context.Vehicles.Where(x=>x.UserId == userid).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool VehicleExist(int id)
        {
            return _context.Vehicles.Any(x => x.VehicleId == id);
        }
    }
}
