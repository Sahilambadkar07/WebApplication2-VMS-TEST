using WebApplication2_VMS_TEST.Data;
using WebApplication2_VMS_TEST.Models;
using WebApplication2_VMS_TEST.Interfaces;

namespace WebApplication2_VMS_TEST.Repository

{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateUser(UserModel user)
        {
            _context.Users.Add(user);
            return Save();
        }

        public ICollection<UserModel> GetUser()
        {
            return _context.Users.OrderBy(x => x.UserId).ToList();
        }

        public UserModel GetUserById(int id)
        {
            return _context.Users.Where(x => x.UserId == id).FirstOrDefault();
        }
        public UserModel GetUserByUsername(string username)
        {
            return _context.Users.Where(x => x.Username.ToLower() == username.ToLower()).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UserExist(int id)
        {
            return _context.Users.Any(x => x.UserId == id);
        }
    }
}
