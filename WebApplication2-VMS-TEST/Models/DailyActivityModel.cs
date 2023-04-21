using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
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
        public int OdometerReading { get; set; }

        [Required]
        public decimal RunningHours { get; set; }

        [Required]
        public decimal AmountOfFuel { get; set; }



    }
}
