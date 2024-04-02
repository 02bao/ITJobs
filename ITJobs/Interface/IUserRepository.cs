using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface IUserRepository
    {
        bool Register(User users);
        ICollection<User> GetUsers();
        User GetById(long userid);
        long Login(User_login userlogin);
    }
}
