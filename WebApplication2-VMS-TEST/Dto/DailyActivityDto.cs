
namespace WebApplication2_VMS_TEST.Dto
{
    public class DailyActivityDto
    {
        

        public int VehicleId { get; set; }

        public DateTime Date { get; set; }

        public int OdometerReading { get; set; }

        public decimal RunningHours { get; set; }

        //public decimal FuelFilled { get; set; }

        //public decimal FuelCost { get; set; }

        public decimal AmountOfFuel { get; set; }

        //public decimal MaintenanceExpense { get; set; }

        //public DateTime ServiceDate { get; set; }
    }
}
