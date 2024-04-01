using ITJobs.DTO;
using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface IUserRepository
    {
        bool Register(User user);
    }
}
