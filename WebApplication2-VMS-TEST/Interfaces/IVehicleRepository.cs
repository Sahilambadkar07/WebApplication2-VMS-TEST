using WebApplication2_VMS_TEST.Models;

namespace WebApplication2_VMS_TEST.Interfaces
{
    public interface IVehicleRepository
    {
        ICollection<VehicleModel> GetVehicle();

        ICollection<VehicleModel> GetVehicleByUserId(int userid);

        VehicleModel GetVehicleById(int id);

        public bool VehicleExist(int id);

        bool CreateVehicle(VehicleModel vehicle);

        bool Save();
    }
}
