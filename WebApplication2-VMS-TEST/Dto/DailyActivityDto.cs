
namespace WebApplication2_VMS_TEST.Dto
{
    public class DailyActivityDto
    {
        

        public int VehicleId { get; set; }

        public DateTime Date { get; set; }

        public int OdometerReading { get; set; }

        public decimal RunningHours { get; set; }

        public decimal AmountOfFuel { get; set; }

    }
}
