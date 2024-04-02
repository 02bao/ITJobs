using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface IUserRepository
    {
        bool Register(User_Register users);
        ICollection<User> GetUsers();
        User GetById(long userid);
        bool Login(User_login user);
        bool Del
    }
}
