using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2_VMS_TEST.Models
{
    public class FuelModel
    {
        [Key]
        public int FueEntrylId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        public virtual VehicleModel Vehicle { get; set; }

        [Required]
        public decimal FuelFilled { get; set; }

        [Required]
        public decimal FuelCost { get; set; }
    }
}
