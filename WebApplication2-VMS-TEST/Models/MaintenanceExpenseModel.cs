using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


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
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string ExpenseDescription { get; set; }

        [Required]
        public decimal ExpenseAmount { get; set; }
    }
}
