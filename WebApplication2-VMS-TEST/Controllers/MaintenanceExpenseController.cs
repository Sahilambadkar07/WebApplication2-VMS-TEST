using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication2_VMS_TEST.Dto;
using WebApplication2_VMS_TEST.Interfaces;
using WebApplication2_VMS_TEST.Models;
using WebApplication2_VMS_TEST.Repository;

namespace WebApplication2_VMS_TEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class MaintenanceExpenseController : Controller
    {
        private readonly IMaintenanceExpenseRepository _maintenanceExpenseRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;


        public MaintenanceExpenseController(IMaintenanceExpenseRepository maintanenceExpenseRepository, IVehicleRepository vehicleRepository,IMapper mapper)
        {
            _maintenanceExpenseRepository = maintanenceExpenseRepository;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<MaintenanceExpenseModel>))]

        public IActionResult GetExpense()
        {
            var expense = _mapper.Map<List<MaintenanceExpensesDto>>(_maintenanceExpenseRepository.GetExpense());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(expense);
        }

        [HttpGet("{expenseId}")]
        [ProducesResponseType(200, Type = typeof(MaintenanceExpenseModel))]
        public IActionResult GetExpense(int expenseId)
        {
            var expense = _mapper.Map<MaintenanceExpensesDto>(_maintenanceExpenseRepository.GetExpenseById(expenseId));
            if (!_maintenanceExpenseRepository.ExpenseExist(expenseId))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(expense);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateMaintenanceExpense([FromBody] MaintenanceExpensesDto maintenanceExpensecreate)
        {
            if (maintenanceExpensecreate == null)
            {
                Console.WriteLine("vehicle null create");
                return BadRequest(ModelState);
            }

            var expense = _maintenanceExpenseRepository.GetExpense().Where(c => c.MaintenanceExpenseId == maintenanceExpensecreate.MaintenanceExpenseId).FirstOrDefault();

            if (expense != null)
            {
                ModelState.AddModelError("", "expense Already Exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ExpenseMap = _mapper.Map<MaintenanceExpenseModel>(maintenanceExpensecreate);

            if (!_vehicleRepository.VehicleExist(ExpenseMap.VehicleId))
            {
                ModelState.AddModelError("", "Vehicle Does not Exists");
                return StatusCode(422, ModelState);
            }


            if (!_maintenanceExpenseRepository.CreateMaintenanceExpense(ExpenseMap))
            {
                ModelState.AddModelError("", "Expense is not Created [VEHICLECONTOLLER]");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created");
        }
    }
}
