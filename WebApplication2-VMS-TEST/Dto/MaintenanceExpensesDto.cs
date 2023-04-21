using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication2_VMS_TEST.Models;

namespace WebApplication2_VMS_TEST.Dto
{
    public class MaintenanceExpensesDto
    {
        public int MaintenanceExpenseId { get; set; }

        public int VehicleId { get; set; }

        public DateTime Date { get; set; }

        public string? ExpenseDescription { get; set; }

        public decimal ExpenseAmount { get; set; }
    }
}
