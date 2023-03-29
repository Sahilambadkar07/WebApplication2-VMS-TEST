using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2_VMS_TEST.Models
{
    public class MaintenanceExpenseModel
    {
        [Key]
        public int MaintenanceExpenseId { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        public virtual VehicleModel Vehicle { get; set; }

        [Required]
        public DateTime ExpenseDate { get; set; }

        [Required]
        [StringLength(50)]
        public string ExpenseDescription { get; set; }

        [Required]
        public decimal ExpenseAmount { get; set; }
    }
}
