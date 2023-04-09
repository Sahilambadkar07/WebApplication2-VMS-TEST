using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication2_VMS_TEST.Dto;
using WebApplication2_VMS_TEST.Interfaces;
using WebApplication2_VMS_TEST.Models;
namespace WebApplication2_VMS_TEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRpository, IMapper mapper)
        {
            _userRepository = userRpository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserModel>))]
        public IActionResult GetUser()
        {
            var user = _mapper.Map<List<UserDto>>(_userRepository.GetUser());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(user);
        }


        [HttpGet("{userdId}")]
        [ProducesResponseType(200, Type = typeof(UserModel))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(int userdId)
        {
            var user = _mapper.Map<UserDto>(_userRepository.GetUserById(userdId));
            if (!_userRepository.UserExist(userdId))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(user);
        }

        [HttpPost("CreateUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateUser([FromBody] UserLoginDto usercreate)
        {

            if (usercreate == null)
            {
                return BadRequest(ModelState);
            }
            var passwordHasher = new PasswordHasher<UserDto>();
            usercreate.Password = passwordHasher.HashPassword(null, usercreate.Password);

            var user = _userRepository.GetUser().Where(c => c.Username.ToLower() == usercreate.Username.ToLower() &&
            c.Password == usercreate.Password).FirstOrDefault();

            if (user != null)
            {
                ModelState.AddModelError("", "User Already Exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var userMap = _mapper.Map<UserModel>(usercreate);

            if (!_userRepository.CreateUser(userMap))
            {
                ModelState.AddModelError("", "User is not Created [USERCONTOLLER]");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }
    }
}
