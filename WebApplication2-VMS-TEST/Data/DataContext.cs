using WebApplication2_VMS_TEST.Models;
using Microsoft.EntityFrameworkCore;
namespace WebApplication2_VMS_TEST.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base()
        {

            Console.WriteLine("Connection Established");
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<VehicleModel> Vehicles { get; set; }
        public DbSet<DailyActivityModel> DailyActivities { get; set; }
        public DbSet<MaintenanceExpenseModel> MaintenanceExpenses { get; set; }
        public DbSet<FuelModel> FuelActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //============================= VEHICLE MODEL ==============================
            modelBuilder.Entity<VehicleModel>()
               .Property(p => p.LastServiceCharge)
               .HasColumnType("decimal(18,4)");
            
            modelBuilder.Entity<VehicleModel>()
                .HasOne(v => v.Users)
                .WithMany(u => u.Vehicles)
                .HasForeignKey(v => v.UserId);

            modelBuilder.Entity<VehicleModel>()
               .Property(p => p.FuelCapacity)
               .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<VehicleModel>()
               .Property(p => p.OdometerReading)
               .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<VehicleModel>()
               .Property(p => p.FuelAmount)
               .HasColumnType("decimal(18,4)");


            //============================= DAILYACTIVTY MODEL ==============================

            modelBuilder.Entity<DailyActivityModel>()
                .Property(p => p.RunningHours)
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<DailyActivityModel>()
                .HasOne(d => d.Vehicle)
                .WithMany(v => v.DailyActivities)
                .HasForeignKey(d => d.VehicleId);

            modelBuilder.Entity<DailyActivityModel>()
                .Property(p => p.AmountOfFuel)
                .HasColumnType("decimal(18,4)");


            //============================= MAINTENANCE MODEL ==============================

            modelBuilder.Entity<MaintenanceExpenseModel>()
               .Property(p => p.ExpenseAmount)
               .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<MaintenanceExpenseModel>()
                .HasOne(m => m.Vehicle)
                .WithMany(v => v.MaintenanceExpenses)
                .HasForeignKey(m => m.VehicleId);

            //============================= FUEL MODEL ==============================

            modelBuilder.Entity<FuelModel>()
                .HasOne(m => m.Vehicle)
                .WithMany(v => v.FuelActivities)
                .HasForeignKey(m => m.VehicleId);
            
            modelBuilder.Entity<FuelModel>()
                .Property(p => p.FuelFilled)
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<FuelModel>()
                .Property(p => p.FuelCost)
                .HasColumnType("decimal(18,4)");
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
