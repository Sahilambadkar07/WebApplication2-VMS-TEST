using WebApplication2_VMS_TEST.Models;
namespace WebApplication2_VMS_TEST.Interfaces
{
    public interface IUserRepository
    {

        ICollection<UserModel> GetUser();
        UserModel GetUserById(int id);
       public bool UserExist(int id);

        bool CreateUser(UserModel user);

        bool Save();

    }
}

