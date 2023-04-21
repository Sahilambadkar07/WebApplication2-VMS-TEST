namespace WebApplication2_VMS_TEST.Dto
{
    public class MaintenanceExpensePostDto
    {

        public int VehicleId { get; set; }

        public DateTime Date { get; set; }

        public string ExpenseDescription { get; set; }

        public decimal ExpenseAmount { get; set; }
    }
}
