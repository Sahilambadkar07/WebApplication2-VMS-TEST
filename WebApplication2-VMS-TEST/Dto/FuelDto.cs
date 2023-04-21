using System.ComponentModel.DataAnnotations;

namespace WebApplication2_VMS_TEST.Dto
{
    public class FuelDto
    {

        public DateTime Date { get; set; }

        public int VehicleId { get; set; }

        public decimal FuelFilled { get; set; }
        
        public decimal FuelCost { get; set; }

    }

}

