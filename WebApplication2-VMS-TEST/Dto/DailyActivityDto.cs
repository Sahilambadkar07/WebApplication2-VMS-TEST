using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication2_VMS_TEST.Models;

namespace WebApplication2_VMS_TEST.Dto
{
    public class DailyActivityDto
    {
        //public int DailyActivityId { get; set; }

        public int VehicleId { get; set; }

        //public virtual VehicleModel Vehicle { get; set; }

        public DateTime Date { get; set; }

        public int OdometerReading { get; set; }

        public decimal RunningHours { get; set; }

        public decimal FuelFilled { get; set; }

        public decimal FuelCost { get; set; }

        public decimal AmountOfFuel { get; set; }

        public decimal MaintenanceExpense { get; set; }

        public DateTime ServiceDate { get; set; }
    }
}
