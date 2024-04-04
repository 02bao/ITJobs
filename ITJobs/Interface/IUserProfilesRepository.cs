using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface IUserProfilesRepository
    {
        bool CreateUserProfiles(long userid , UserProfiles users);
        ICollection<UserProfiles> GetAll();
        UserProfiles GetById(long userprofileId);
        bool GetByUserId(long userId);  
    }
}
