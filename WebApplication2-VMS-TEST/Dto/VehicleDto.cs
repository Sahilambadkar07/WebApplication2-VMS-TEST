using AutoMapper;
using WebApplication2_VMS_TEST.Models;

namespace WebApplication2_VMS_TEST.Dto
{
    public class VehicleDto
    {
        public int VehicleId { get; set; }

        public int UserId { get; set; }

        //public virtual UserModel Users { get; set; }

        public string VehicleType { get; set; }

        public string VehicleNumber { get; set; }

        public bool IsSmartVehicle { get; set; }

        public string FuelType { get; set; }

        public decimal FuelCapacity { get; set; }

        public int OdometerReading { get; set; }

        public DateTime LastServiceDate { get; set; }

        public decimal LastServiceCharge { get; set; }

        public decimal FuelAmount { get; set; }

    }
}
