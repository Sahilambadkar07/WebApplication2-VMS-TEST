using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication2_VMS_TEST.Data;
using WebApplication2_VMS_TEST.Dto;
using WebApplication2_VMS_TEST.Interfaces;
using WebApplication2_VMS_TEST.Models;

namespace WebApplication2_VMS_TEST.Repository
{
    public class DashBoardRepository : IDashBoardRepository
    {
        private readonly DataContext _context;
        public DashBoardRepository(DataContext context)
        {
            _context = context;
        }
        //================= [ SECTION - A ] =================\\
        public int GetCurrentOdodmeterReading(int vehicleid)
        {
            var vehicle = _context.DailyActivities.Where(x => x.VehicleId == vehicleid);
            return vehicle.OrderByDescending(c => c.DailyActivityId).Select(x => x.OdometerReading).FirstOrDefault();
        }

        public decimal GetRemainingFuelAmount(int vehicleid)
        {
            var vehicle = _context.DailyActivities.Where(x => x.VehicleId == vehicleid);
            return vehicle.OrderBy(c => c.DailyActivityId).Select(x => x.AmountOfFuel).FirstOrDefault();
        }
        //public decimal Average_Km_Ltr(int vehicleid)
        public decimal Average_Km_Ltr(int vehicleid, DateTime? startdate = null, DateTime? enddate = null)
        {

            //set the date range ()start date and the end date also the default date range.

            var dailyactivityOfVehicle = _context.DailyActivities.Where(x => x.VehicleId == vehicleid && x.Date >= startdate && x.Date <= enddate);
            var sum = dailyactivityOfVehicle.Sum(x => Math.Abs(x.FuelFilled - x.AmountOfFuel));
            var odo = dailyactivityOfVehicle.OrderByDescending(c => c.DailyActivityId).Select(x => x.OdometerReading).FirstOrDefault();
            if (odo == 0)
            {
                return 0;
            }
            return (odo / sum);

        }

        public decimal FuelExpenses(int vehicleid, DateTime? startdate, DateTime? enddate)
        {
            var dailyactivityOfVehicle = _context.DailyActivities.Where(x => x.VehicleId == vehicleid && x.Date >= startdate && x.Date <= enddate);
            var sum = dailyactivityOfVehicle.Sum(x => x.FuelCost);
            if (sum == 0)
            {
                return 0;
            }
            return (sum);
        }

        public decimal MaintExpenses(int vehicleid, DateTime? startdate, DateTime? enddate)
        {
            var dailyactivityOfVehicle = _context.DailyActivities.Where(x => x.VehicleId == vehicleid && x.Date >= startdate && x.Date <= enddate);
            var maintexp = dailyactivityOfVehicle.Sum(x => x.MaintenanceExpense);

            var serviceexp = _context.Vehicles.Where(x => x.VehicleId == vehicleid).Select(c => c.LastServiceCharge).FirstOrDefault();
            if (maintexp == 0)
            {
                return serviceexp;
            }
            return (serviceexp + maintexp);
        }

        public decimal TotalExpPerDay(int vehicleid, DateTime? startdate, DateTime? enddate)
        {
            var dailyactivityOfVehicle = _context.DailyActivities.Where(x => x.VehicleId == vehicleid && x.Date >= startdate && x.Date <= enddate);
            var count = dailyactivityOfVehicle.Count();

            if (count == 0)
            {
                return 0;
            }
            var maintexp = dailyactivityOfVehicle.Sum(x => x.MaintenanceExpense);
            var serviceexp = _context.Vehicles.Where(x => x.VehicleId == vehicleid).Select(c => c.LastServiceCharge).FirstOrDefault();
            var fuelexp = dailyactivityOfVehicle.Sum(x => x.FuelCost);
            var totalexp = fuelexp + serviceexp + maintexp;


            return (totalexp / count);
        }

        public decimal RsPerKm(int vehicleid, DateTime? startdate, DateTime? enddate)
        {
            var dailyactivityOfVehicle = _context.DailyActivities.Where(x => x.VehicleId == vehicleid && x.Date >= startdate && x.Date <= enddate);

            var maintexp = dailyactivityOfVehicle.Sum(x => x.MaintenanceExpense);
            var serviceexp = _context.Vehicles.Where(x => x.VehicleId == vehicleid).Select(c => c.LastServiceCharge).FirstOrDefault();
            var fuelexp = dailyactivityOfVehicle.Sum(x => x.FuelCost);

            var totalexp = fuelexp + serviceexp + maintexp;

            var odo = dailyactivityOfVehicle.OrderByDescending(c => c.DailyActivityId).Select(x => x.OdometerReading).First();

            return (totalexp / odo);

        }

        public decimal KmPerDay(int vehicleid, DateTime? startdate, DateTime? enddate)
        {
            var dailyactivityOfVehicle = _context.DailyActivities.Where(x => x.VehicleId == vehicleid && x.Date >= startdate && x.Date <= enddate);
            var count = dailyactivityOfVehicle.Count();

            if (count == 0)
            {
                return 0;
            }
            var odo = dailyactivityOfVehicle.OrderByDescending(c => c.DailyActivityId).Select(x => x.OdometerReading).First();

            return (odo / count);
        }

        public decimal AvgFuelComPerDay(int vehicleid, DateTime? startdate, DateTime? enddate)
        {
            var dailyactivityOfVehicle = _context.DailyActivities.Where(x => x.VehicleId == vehicleid && x.Date >= startdate && x.Date <= enddate);
            var count = dailyactivityOfVehicle.Count();

            if (count == 0)
            {
                return 0;
            }
            var sum = dailyactivityOfVehicle.Sum(x => Math.Abs(x.FuelFilled - x.AmountOfFuel));

            return (sum / count);

        }

        public decimal AvgMaintPerDay(int vehicleid, DateTime? startdate, DateTime? enddate)
        {
            var dailyactivityOfVehicle = _context.DailyActivities.Where(x => x.VehicleId == vehicleid && x.Date >= startdate && x.Date <= enddate);
            var count = dailyactivityOfVehicle.Count();

            if (count == 0)
            {
                return 0;
            }
            var sum = dailyactivityOfVehicle.Sum(x => x.MaintenanceExpense);
            return (sum / count);

        }
    }
}

