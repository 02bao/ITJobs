using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface IUserProfilesRepository
    {
        bool CreateUserProfiles(long userid , UserProfiles users);
    }
}
