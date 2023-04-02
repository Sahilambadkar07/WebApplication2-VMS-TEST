using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using WebApplication2_VMS_TEST.Dto;
using WebApplication2_VMS_TEST.Interfaces;
using WebApplication2_VMS_TEST.Models;
using WebApplication2_VMS_TEST.Repository;

namespace WebApplication2_VMS_TEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : Controller
    {
        private readonly IDashBoardRepository _dashboardRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IDailyActivityRepository _dailyActivityRepository;
        private readonly IMapper _mapper;
        public DashBoardController(IDashBoardRepository dashboardRepository, IVehicleRepository vehicleRepository, IDailyActivityRepository dailyActivityRepository, IMapper mapper)
        {
            _dashboardRepository = dashboardRepository;
            _vehicleRepository = vehicleRepository;
            _dailyActivityRepository = dailyActivityRepository;
            _mapper = mapper;
        }

        [HttpGet("GetCurrentOdodmeterReading")]
        [ProducesResponseType(200, Type = typeof(int))]
        public IActionResult GetCurrentOdodmeterReading([FromQuery] int vehicleid)
        {
            var odo = _dashboardRepository.GetCurrentOdodmeterReading(vehicleid);
            return Ok(odo);
        }

        [HttpGet("GetRemainingFuelAmount")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public IActionResult GetRemainingFuelAmount([FromQuery] int vehicleid)
        {
            var fuelAmount = _dashboardRepository.GetRemainingFuelAmount(vehicleid);
            return Ok(fuelAmount);
        }

        [HttpGet("Avg_Km/Ltr")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public IActionResult Average_Km_Ltr([FromQuery] int vehicleid, DateTime? startdate = null, DateTime? enddate = null)
        {
            if (startdate == null && enddate == null)
            {
                enddate = DateTime.Now;
                DateTime end = enddate.Value;
                startdate = new DateTime(end.Year, end.Month, 1);
            }
            if (startdate == null)
            {
                DateTime end = enddate.Value;
                startdate = new DateTime(end.Year, end.Month, 1);
            }
            if (enddate == null)
            {
                DateTime start = startdate.Value;
                int day = DateTime.DaysInMonth(start.Year, start.Month);
                enddate = new DateTime(start.Year, start.Month, day);
            }

            var avg = _dashboardRepository.Average_Km_Ltr(vehicleid, startdate, enddate);
            return Ok(avg);
        }

        [HttpGet("FuelExpenses")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public IActionResult FuelExpenses([FromQuery] int vehicleid, DateTime? startdate = null, DateTime? enddate = null)
        {
            if (startdate == null && enddate == null)
            {
                enddate = DateTime.Now;
                DateTime end = enddate.Value;
                startdate = new DateTime(end.Year, end.Month, 1);
            }
            if (startdate == null)
            {
                DateTime end = enddate.Value;
                startdate = new DateTime(end.Year, end.Month, 1);
            }
            if (enddate == null)
            {
                DateTime start = startdate.Value;
                int day = DateTime.DaysInMonth(start.Year, start.Month);
                enddate = new DateTime(start.Year, start.Month, day);

            }

            var expense = _dashboardRepository.FuelExpenses(vehicleid, startdate, enddate);
            return Ok(expense);
        }

        [HttpGet("MaintExpenses")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public IActionResult MaintExpenses([FromQuery] int vehicleid, DateTime? startdate = null, DateTime? enddate = null)
        {
            if (startdate == null && enddate == null)
            {
                enddate = DateTime.Now;
                DateTime end = enddate.Value;
                startdate = new DateTime(end.Year, end.Month, 1);
            }
            if (startdate == null)
            {
                DateTime end = enddate.Value;
                startdate = new DateTime(end.Year, end.Month, 1);
            }
            if (enddate == null)
            {
                DateTime start = startdate.Value;
                int day = DateTime.DaysInMonth(start.Year, start.Month);
                enddate = new DateTime(start.Year, start.Month, day);

            }
            var expense = _dashboardRepository.MaintExpenses(vehicleid, startdate, enddate);
            return Ok(expense);
        }

        [HttpGet("Tabularview")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DailyActivityModel>))]
        public IActionResult GetTabularView([FromQuery] int vehicleid)
        {
            var dailyActivities = _dailyActivityRepository.GetDailyActivityByVehicleId(vehicleid);
            var tabularViewDtoList = _mapper.Map<List<TabularViewDto>>(dailyActivities);
            var prevdto = tabularViewDtoList[0];
            int flag = 0;
            foreach (var dto in tabularViewDtoList)
            {
                if (flag == 0)
                {
                    flag = 1;
                    dto.KmRun = dto.OdometerReading;
                }
                else
                {
                    dto.KmRun = dto.OdometerReading - prevdto.OdometerReading;
                    prevdto = dto;
                }
            }
            return Ok(tabularViewDtoList);
        }


        [HttpGet("TotalExpPerDay")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public IActionResult TotalExpPerDay([FromQuery] int vehicleid, DateTime? startdate = null, DateTime? enddate = null)
        {
            if (startdate == null && enddate == null)
            {
                enddate = DateTime.Now;
                DateTime end = enddate.Value;
                startdate = new DateTime(end.Year, end.Month, 1);
            }
            if (startdate == null)
            {
                DateTime end = enddate.Value;
                startdate = new DateTime(end.Year, end.Month, 1);
            }
            if (enddate == null)
            {
                DateTime start = startdate.Value;
                int day = DateTime.DaysInMonth(start.Year, start.Month);
                enddate = new DateTime(start.Year, start.Month, day);
            }
            var totalexpperdat = _dashboardRepository.TotalExpPerDay(vehicleid, startdate, enddate);
            return Ok(totalexpperdat);  
        }

        [HttpGet("RsPerKm")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public IActionResult RsPerKm([FromQuery] int vehicleid, DateTime? startdate = null, DateTime? enddate = null)
        {
            if (startdate == null && enddate == null)
            {
                enddate = DateTime.Now;
                DateTime end = enddate.Value;
                startdate = new DateTime(end.Year, end.Month, 1);
            }
            if (startdate == null)
            {
                DateTime end = enddate.Value;
                startdate = new DateTime(end.Year, end.Month, 1);
            }
            if (enddate == null)
            {
                DateTime start = startdate.Value;
                int day = DateTime.DaysInMonth(start.Year, start.Month);
                enddate = new DateTime(start.Year, start.Month, day);
            }
            var rsperkm = _dashboardRepository.RsPerKm(vehicleid, startdate, enddate);
            return Ok(rsperkm);
        }

        [HttpGet("KmPerDay")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public IActionResult KmPerDay([FromQuery] int vehicleid, DateTime? startdate = null, DateTime? enddate = null)
        {
            if (startdate == null && enddate == null)
            {
                enddate = DateTime.Now;
                DateTime end = enddate.Value;
                startdate = new DateTime(end.Year, end.Month, 1);
            }
            if (startdate == null)
            {
                DateTime end = enddate.Value;
                startdate = new DateTime(end.Year, end.Month, 1);
            }
            if (enddate == null)
            {
                DateTime start = startdate.Value;
                int day = DateTime.DaysInMonth(start.Year, start.Month);
                enddate = new DateTime(start.Year, start.Month, day);
            }
            var kmperday = _dashboardRepository.KmPerDay(vehicleid, startdate, enddate);
            return Ok(kmperday);
        }

        [HttpGet("FuelComPerDay")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public IActionResult FuelComPerDay([FromQuery] int vehicleid, DateTime? startdate = null, DateTime? enddate = null)
        {
            if (startdate == null && enddate == null)
            {
                enddate = DateTime.Now;
                DateTime end = enddate.Value;
                startdate = new DateTime(end.Year, end.Month, 1);
            }
            if (startdate == null)
            {
                DateTime end = enddate.Value;
                startdate = new DateTime(end.Year, end.Month, 1);
            }
            if (enddate == null)
            {
                DateTime start = startdate.Value;
                int day = DateTime.DaysInMonth(start.Year, start.Month);
                enddate = new DateTime(start.Year, start.Month, day);
            }
            var fuelcomPerday = _dashboardRepository.AvgFuelComPerDay(vehicleid, startdate, enddate);
            return Ok(fuelcomPerday);
        }

        [HttpGet("MaintCostPerDay")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public IActionResult MaintCostPerDay([FromQuery] int vehicleid, DateTime? startdate = null, DateTime? enddate = null)
        {
            if (startdate == null && enddate == null)
            {
                enddate = DateTime.Now;
                DateTime end = enddate.Value;
                startdate = new DateTime(end.Year, end.Month, 1);
            }
            if (startdate == null)
            {
                DateTime end = enddate.Value;
                startdate = new DateTime(end.Year, end.Month, 1);
            }
            if (enddate == null)
            {
                DateTime start = startdate.Value;
                int day = DateTime.DaysInMonth(start.Year, start.Month);
                enddate = new DateTime(start.Year, start.Month, day);
            }
            var maintcostperday = _dashboardRepository.AvgMaintPerDay(vehicleid, startdate, enddate);
            return Ok(maintcostperday);
        }
    }
}
