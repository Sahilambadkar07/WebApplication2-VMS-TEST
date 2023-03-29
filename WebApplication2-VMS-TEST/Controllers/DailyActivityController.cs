using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication2_VMS_TEST.Data;
using WebApplication2_VMS_TEST.Dto;
using WebApplication2_VMS_TEST.Interfaces;
using WebApplication2_VMS_TEST.Models;
using WebApplication2_VMS_TEST.Repository;

namespace WebApplication2_VMS_TEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyActivityController : Controller
    {
        private readonly IDailyActivityRepository _dailyActivityRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;
        public DailyActivityController(IDailyActivityRepository dailyActivityRepository ,IVehicleRepository vehicleRepository ,IMapper mapper)
        {
            _dailyActivityRepository = dailyActivityRepository;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DailyActivityModel>))]
         
        public IActionResult GetDailyActivity() {
            var activity = _mapper.Map<List<DailyActivityDto>>(_dailyActivityRepository.GetDailyActivity());
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);  
            }
            return Ok(activity);
        }

        [HttpGet("{dailyActivityId}")]
        [ProducesResponseType(200, Type = typeof(DailyActivityModel))]

        public IActionResult GetDailyActivity(int dailyActivityId)
        {
            var activity = _mapper.Map<DailyActivityDto>(_dailyActivityRepository.GetDailyActivityById(dailyActivityId));
            if (!_dailyActivityRepository.DailyActivityExist(dailyActivityId))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(activity);
        }

        [HttpGet("GetCurrentOdodmeterReading")]
        [ProducesResponseType(200, Type = typeof(int))]
        public IActionResult GetCurrentOdodmeterReading()
        {
            var odo  = _dailyActivityRepository.GetCurrentOdodmeterReading();
            return Ok(odo);
        }

        [HttpGet("GetRemainingFuelAmount")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public IActionResult GetRemainingFuelAmount()
        {
            var fuelAmount = _dailyActivityRepository.GetRemainingFuelAmount();
            return Ok(fuelAmount);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDailyActivity([FromBody] DailyActivityDto dailyActivitycreate)
        {
            if (dailyActivitycreate == null)
            {
                Console.WriteLine("vehicle null create");
                return BadRequest(ModelState);
            }

            var activity = _dailyActivityRepository.GetDailyActivity().Where(c => c.DailyActivityId == dailyActivitycreate.DailyActivityId).FirstOrDefault();

            if (activity != null)
            {
                ModelState.AddModelError("", "activity Already Exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ActivityMap = _mapper.Map<DailyActivityModel>(dailyActivitycreate);

            if (!_vehicleRepository.VehicleExist(ActivityMap.VehicleId))
            {
                ModelState.AddModelError("", "Vehicle Does not Exists");
                return StatusCode(422, ModelState);
            }


            if (!_dailyActivityRepository.CreateDailyActivity(ActivityMap))
            {
                ModelState.AddModelError("", "Activity is not Created [VEHICLECONTOLLER]");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created");
        }
    }


}
