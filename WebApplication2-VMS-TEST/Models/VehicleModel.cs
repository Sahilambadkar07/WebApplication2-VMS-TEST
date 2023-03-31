using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2_VMS_TEST.Models
{
     public class VehicleModel
    {
        [Key]
        public int VehicleId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserModel Users { get; set; }

        [Required]
        [StringLength(50)]
        public string VehicleType { get; set; }

        [Required]
        [StringLength(50)]
        public string VehicleNumber { get; set; }

        [Required]
        public bool IsSmartVehicle { get; set; }

        [Required]
        [StringLength(50)]
        public string FuelType { get; set; }

        [Required]
        public decimal FuelCapacity { get; set; }

        [Required]
        public int OdometerReading { get; set; }

        public DateTime? LastServiceDate { get; set; }

        public decimal LastServiceCharge { get; set; }

        [Required]
        public decimal FuelAmount { get; set; }

        public virtual ICollection<DailyActivityModel> DailyActivities { get; set; }

        
        public virtual ICollection<MaintenanceExpenseModel> MaintenanceExpenses { get; set; }
    }
}
