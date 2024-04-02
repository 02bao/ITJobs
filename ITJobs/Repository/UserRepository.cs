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

        //public bool Delete(long userid)
        //{
        //    User user = _context.Users.FirstOrDefault( s => s.Id == userid );
        //    if( user == null )
        //    {
        //        return false;
        //    }
        //    _context.Users.Remove( user );
        //    _context.SaveChanges();
        //    return true;
        //}

        //public User GetById(long userid)
        //{
        //    return _context.Users.FirstOrDefault( u => u.Id == userid );
        //}

        //public ICollection<User> GetUsers()
        //{
        //    return _context.Users.ToList();
        //}

        //public long Login(User_login user)
        //{
        //    var users = _context.Users.Where()
        //}

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

        //public bool Update(User_Update user)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
