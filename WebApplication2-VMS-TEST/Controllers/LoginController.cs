using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApplication2_VMS_TEST.Interfaces;
using WebApplication2_VMS_TEST.Models;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.AspNetCore.Authorization;

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

        private UserModel AuthenticateUser(UserModel user)
        {
            var User = _userRepository.GetUserById(user.UserId);
            if (User == null)
            {
                // if nulls then what ..implemet it later
            }
            return user;
        }

        private string GenerateToken(UserModel user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt: Issuer"], _config["Jwt: Audience"], null,
                 expires: DateTime.Now.AddMinutes(1),
                 signingCredentials: credentials
                 );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
    }
}
