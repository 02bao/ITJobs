using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface IUserProfilesRepository
    {
        bool CreateUserProfiles(long userid , UserProfiles users);
        ICollection<UserProfiles> GetAll();
        UserProfiles GetById(long userprofileId);
        List<UserProfiles> GetByUserId(long userId);  
        bool Update(UserProfiles userprofile, IFormFile avaterfile);
    }
}
