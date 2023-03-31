using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2_VMS_TEST.Models
{
    public class DailyActivityModel
    {
        [Key]
        public int DailyActivityId { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        public virtual VehicleModel Vehicle { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int OdometerReading { get; set; } //validation that vehicle.odo <= dailyact.odo

        [Required]
        public decimal RunningHours { get; set; }

        [Required]
        public decimal FuelFilled { get; set; }

        [Required]
        public decimal FuelCost { get; set; }

        [Required]

        public decimal AmountOfFuel { get; set; }

        [Required]
        public decimal MaintenanceExpense { get; set; }

        public DateTime ServiceDate { get; set; }

    }
}
