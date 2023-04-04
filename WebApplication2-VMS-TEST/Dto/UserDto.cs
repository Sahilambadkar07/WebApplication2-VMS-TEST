using System.ComponentModel.DataAnnotations;

namespace WebApplication2_VMS_TEST.Dto
{
    public class UserDto
    {

        
        public int UserId { get; set; }
        
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
