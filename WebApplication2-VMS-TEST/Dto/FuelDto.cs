using System.ComponentModel.DataAnnotations;

namespace WebApplication2_VMS_TEST.Dto
{
    public class FuelDto
    {

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [Required]
        public decimal FuelFilled { get; set; }

        [Required]
        public decimal FuelCost { get; set; }

    }

}

