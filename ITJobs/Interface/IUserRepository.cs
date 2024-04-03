using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface IUserRepository
    {
        bool Register(User user);
        ICollection<User> GetAll();
        User GetById(long userid);
        long Login(User_login users);
        bool Update(User user);
        bool Delete(long userid);
    }
}
