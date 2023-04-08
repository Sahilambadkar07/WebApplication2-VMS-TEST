
using System.ComponentModel.DataAnnotations;


namespace WebApplication2_VMS_TEST.Models
{
     public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        
        public virtual ICollection<VehicleModel> Vehicles { get; set; }
    }
}
