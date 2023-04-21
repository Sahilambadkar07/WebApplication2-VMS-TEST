using WebApplication2_VMS_TEST.Models;

namespace WebApplication2_VMS_TEST.Interfaces
{
    public interface IMaintenanceExpenseRepository
    {
        ICollection<MaintenanceExpenseModel> GetExpense();
       
        MaintenanceExpenseModel GetExpenseById(int id);

        public bool ExpenseExist(int id);

        bool CreateMaintenanceExpense(MaintenanceExpenseModel maintenanceExpense);

        bool Save();
    }
}
