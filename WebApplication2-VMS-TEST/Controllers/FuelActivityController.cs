using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication2_VMS_TEST.Dto;
using WebApplication2_VMS_TEST.Interfaces;
using WebApplication2_VMS_TEST.Models;

namespace WebApplication2_VMS_TEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelActivityController : Controller
    {
        private readonly IFuelRepository _fuelRepository;
        private readonly IMapper _mapper;

        public FuelActivityController(IFuelRepository fuelRepository, IMapper mapper)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
        }

        [HttpPost("CreateFuelActivity")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateFuelActivity([FromBody] FuelDto fuelActivitycreate)
        {

            if (fuelActivitycreate == null)
            {
                return BadRequest(ModelState);
            }


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var fuelEntryMap = _mapper.Map<FuelModel>(fuelActivitycreate);

            if (!_fuelRepository.CreateFuelActivity(fuelEntryMap))
            {
                ModelState.AddModelError("", "User is not Created [USERCONTOLLER]");
                return StatusCode(500, ModelState);
            }

            return Ok(_fuelRepository.GetFuelEntryById(fuelEntryMap.FueEntrylId));
        }

        
        [HttpGet("GetFuelActivityByVehicleId/{vehicleId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FuelModel>))]
        public IActionResult GetFuelActivityByVehicleId(int vehicleId)
        {
            var fuelactivity = _mapper.Map<List<FuelDto>>(_fuelRepository.GetFuelActivityByVehicleId(vehicleId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(fuelactivity);
        }
    }
}
