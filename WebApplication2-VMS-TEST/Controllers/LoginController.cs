using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using WebApplication2_VMS_TEST.Interfaces;
using WebApplication2_VMS_TEST.Dto;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;

namespace WebApplication2_VMS_TEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private IConfiguration _config;
        public LoginController(IConfiguration config, IUserRepository userRepository)
        {
            _config = config;
            _userRepository = userRepository;
        }

        private UserLoginDto? AuthenticateUser(UserLoginDto user)
        {
            var _user = _userRepository.GetUserByUsername(user.Username);
            var passwordHasher = new PasswordHasher<UserLoginDto>();

            var success = (passwordHasher.VerifyHashedPassword(null, _user.Password, user.Password) == PasswordVerificationResult.Success);
            if (_user == null )
            {
                return null;
                // if nulls then what ..implemet it later
            }
            if (!success)
            {
                return null;
            }
            return user;
        }

        private string GenerateToken(UserLoginDto user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null,
                 expires: DateTime.Now.AddMinutes(1),
                 signingCredentials: credentials
                 );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(UserLoginDto user)
        {
            IActionResult response = Unauthorized();
            var _user = AuthenticateUser(user);
            if (_user != null)
            {
                var token =  GenerateToken(_user);
                response = Ok(new { token = token });
            }
            return response;
        }
    }
}
