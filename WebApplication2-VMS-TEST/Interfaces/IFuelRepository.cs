using WebApplication2_VMS_TEST.Models;

namespace WebApplication2_VMS_TEST.Interfaces
{
    public interface IFuelRepository
    {
        ICollection<FuelModel> GetFuelActivityByVehicleId(int vehicleid);

        FuelModel GetFuelEntryById(int fuelId);

        decimal GetFuelFilledEntryByDate(DateTime date , int vehicleid);

        bool CreateFuelActivity(FuelModel fuelEntry);

        bool Save();
    }
}

