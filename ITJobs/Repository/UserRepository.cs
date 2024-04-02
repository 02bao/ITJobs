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
        public bool Register(User_Register users)
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
                Role = "",
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }
    }
}
