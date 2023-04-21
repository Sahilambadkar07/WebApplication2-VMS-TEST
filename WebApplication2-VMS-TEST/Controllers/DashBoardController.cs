using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication2_VMS_TEST.Dto;
using WebApplication2_VMS_TEST.Interfaces;
using WebApplication2_VMS_TEST.Models;

namespace WebApplication2_VMS_TEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class DashBoardController : Controller
    {
        private readonly IDashBoardRepository _dashboardRepository;
        private readonly IFuelRepository _fuelRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IDailyActivityRepository _dailyActivityRepository;
        private readonly IMapper _mapper;
        public DashBoardController(

            IDashBoardRepository dashboardRepository,
            IVehicleRepository vehicleRepository,
            IDailyActivityRepository dailyActivityRepository,
            IFuelRepository fuelRepository,
            IMapper mapper)
        {
            _fuelRepository = fuelRepository;
            _dashboardRepository = dashboardRepository;
            _vehicleRepository = vehicleRepository;
            _dailyActivityRepository = dailyActivityRepository;
            _mapper = mapper;
        }

        [HttpGet("GetCurrentOdodmeterReading/{vehicleid}")]
        [ProducesResponseType(200, Type = typeof(int))]
        public IActionResult GetCurrentOdodmeterReading(int vehicleid)
        {
            var odo = _dashboardRepository.GetCurrentOdodmeterReading(vehicleid);
            return Ok(odo);
        }

        [HttpGet("GetRemainingFuelAmount/{vehicleid}")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public IActionResult GetRemainingFuelAmount(int vehicleid)
        {
            var fuelAmount = _dashboardRepository.GetRemainingFuelAmount(vehicleid);
            return Ok(fuelAmount);
        }

        [HttpGet("Avg_Km_Per_Ltr/{vehicleid}/{startdate}/{enddate}")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public IActionResult Average_Km_Ltr(int vehicleid, DateTime? startdate = null, DateTime? enddate = null)
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

        [HttpGet("FuelExpenses/{vehicleid}/{startdate}/{enddate}")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public IActionResult FuelExpenses(int vehicleid, DateTime? startdate = null, DateTime? enddate = null)
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

        [HttpGet("MaintExpenses/{vehicleid}/{startdate}/{enddate}")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public IActionResult MaintExpenses(int vehicleid, DateTime? startdate = null, DateTime? enddate = null)
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

        // date filtering is remaining

        [HttpGet("Tabularview/{vehicleid}/{startdate}/{enddate}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DailyActivityModel>))]
        public IActionResult GetTabularView(int vehicleid, DateTime? startdate = null, DateTime? enddate = null)
        {
            var dailyActivities = _dailyActivityRepository.GetDailyActivityByVehicleId(vehicleid);
            var fuelActivities = _fuelRepository.GetFuelActivityByVehicleId(vehicleid);
            var fuelActivitiesDto = _mapper.Map<List<FuelDto>>(fuelActivities);
            var tabularViewDtoList = _mapper.Map<List<TabularViewDto>>(dailyActivities);
            dynamic prevdto = null;
            dynamic prevfuelActi = null;
            if (tabularViewDtoList.Any())
            {
                prevdto = tabularViewDtoList[0];
            }

            if (fuelActivities.Any())
            {
                prevfuelActi = fuelActivitiesDto[0];
            }
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
                dto.FuelFilled = _fuelRepository.GetFuelFilledEntryByDate(dto.Date,vehicleid);

            }
            return Ok(tabularViewDtoList);
        }


        [HttpGet("TotalExpPerDay/{vehicleid}/{startdate}/{enddate}")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public IActionResult TotalExpPerDay(int vehicleid, DateTime? startdate = null, DateTime? enddate = null)
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

        [HttpGet("RsPerKm/{vehicleid}/{startdate}/{enddate}")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public IActionResult RsPerKm(int vehicleid, DateTime? startdate = null, DateTime? enddate = null)
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

        [HttpGet("KmPerDay/{vehicleid}/{startdate}/{enddate}")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public IActionResult KmPerDay(int vehicleid, DateTime? startdate = null, DateTime? enddate = null)
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

        [HttpGet("FuelComPerDay/{vehicleid}/{startdate}/{enddate}")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public IActionResult FuelComPerDay(int vehicleid, DateTime? startdate = null, DateTime? enddate = null)
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

        [HttpGet("MaintCostPerDay/{vehicleid}/{startdate}/{enddate}")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public IActionResult MaintCostPerDay(int vehicleid, DateTime? startdate = null, DateTime? enddate = null)
        {
            //if (startdate == null && enddate == null)
            //{
            //    enddate = DateTime.Now;
            //    DateTime end = enddate.Value;
            //    startdate = new DateTime(end.Year, end.Month, 1);
            //}
            //if (startdate == null)
            //{
            //    DateTime end = enddate.Value;
            //    startdate = new DateTime(end.Year, end.Month, 1);
            //}
            //if (enddate == null)
            //{
            //    DateTime start = startdate.Value;
            //    int day = DateTime.DaysInMonth(start.Year, start.Month);
            //    enddate = new DateTime(start.Year, start.Month, day);
            //}
            var maintcostperday = _dashboardRepository.AvgMaintPerDay(vehicleid, startdate, enddate);
            return Ok(maintcostperday);
        }
    }
}
