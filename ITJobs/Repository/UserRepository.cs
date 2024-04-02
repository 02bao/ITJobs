using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Models;

namespace ITJobs.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public User GetById(long userid)
        {
            return _context.Users.FirstOrDefault(s => s.Id == userid);
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public long Login(User_login userlogin)
        {
            var users = _context.Users.FirstOrDefault(u => u.UserName == userlogin.UserName
                                        && u.Password == userlogin.Password);
            if(users == null)
            {
                return -1;
            }
            return users.Id;
        }

        public bool Register(User users)
        {
            var useremail = _context.Users.SingleOrDefault(s => s.Email == users.Email);
            if(useremail != null)
            {
                return false;
            }
            User user = new User()
            {
                UserName = users.UserName,
                Email = users.Email,
                Password = users.Password,
                Role = users.Role,
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

    }
}
