using WebApplication2_VMS_TEST.Interfaces;
using WebApplication2_VMS_TEST.Data;
using WebApplication2_VMS_TEST.Models;

namespace WebApplication2_VMS_TEST.Repository
{
    public class MaintenanceExpenseRepository : IMaintenanceExpenseRepository
    {
        private readonly DataContext _context;

        public MaintenanceExpenseRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateMaintenanceExpense(MaintenanceExpenseModel maintenanceExpense)
        {
            _context.MaintenanceExpenses.Add(maintenanceExpense);
            return Save();
        }

        public bool ExpenseExist(int id)
        {
            return _context.MaintenanceExpenses.Any(x => x.MaintenanceExpenseId == id);

        }

        public ICollection<MaintenanceExpenseModel> GetExpense()
        {
            return _context.MaintenanceExpenses.OrderBy(x => x.MaintenanceExpenseId).ToList();
        }

        public MaintenanceExpenseModel GetExpenseById(int id)
        {
            return _context.MaintenanceExpenses.Where(x => x.MaintenanceExpenseId == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
