namespace WebApplication2_VMS_TEST.Dto
{
    public class MaintenanceExpensePostDto
    {
        public int MaintenanceExpenseId { get; set; }

        public int VehicleId { get; set; }

        //public virtual VehicleModel Vehicle { get; set; }

        public DateTime ExpenseDate { get; set; }

        public string ExpenseDescription { get; set; }

        public decimal ExpenseAmount { get; set; }
    }
}
