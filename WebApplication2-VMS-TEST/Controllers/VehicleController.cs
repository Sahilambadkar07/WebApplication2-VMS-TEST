﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication2_VMS_TEST.Dto;
using WebApplication2_VMS_TEST.Interfaces;
using WebApplication2_VMS_TEST.Models;
using WebApplication2_VMS_TEST.Repository;

namespace WebApplication2_VMS_TEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public VehicleController(IVehicleRepository vehicleRepository,IUserRepository userRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<VehicleModel>))]
        public IActionResult GetVehicle()
        {
            var vehicle = _mapper.Map<List<VehicleDto>>(_vehicleRepository.GetVehicle());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(vehicle);
        }


        [HttpGet("{vehicleId}")]
        [ProducesResponseType(200, Type = typeof(VehicleModel))]
        public IActionResult GetVehicle(int vehicleId)
        {
            var vehicle = _mapper.Map<VehicleDto>(_vehicleRepository.GetVehicleById(vehicleId));
            if (!_vehicleRepository.VehicleExist(vehicleId))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(vehicle);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateVehicle([FromBody] VehicleDto vehiclecreate)
        {
            if (vehiclecreate == null)
            {
                Console.WriteLine("vehicle null create");
                return BadRequest(ModelState);
            }

            var vehicle = _vehicleRepository.GetVehicle().Where(c => c.VehicleId == vehiclecreate.VehicleId).FirstOrDefault();
            
            if (vehicle != null)
            {
                ModelState.AddModelError("", "vehicle Already Exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicleMap = _mapper.Map<VehicleModel>(vehiclecreate);

            if (!_userRepository.UserExist(vehicleMap.UserId))
            {
                ModelState.AddModelError("", "User Does not Exists");
                return StatusCode(422, ModelState);
            }

            if (!_vehicleRepository.CreateVehicle(vehicleMap))
            {
                ModelState.AddModelError("", "Vehicle is not Created [VEHICLECONTOLLER]");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created");
        }
    }
}
