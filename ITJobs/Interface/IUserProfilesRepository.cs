using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface IUserProfilesRepository
    {
        bool CreateUserProfiles(long userid , UserProfiles_Create users);
        ICollection<UserProfiles> GetAll();
        UserProfiles GetById(long userprofileId);
        List<UserProfiles> GetByUserId(long userId);  
        bool Update(UserProfiles userprofile, List<IFormFile> avaterfile);
        bool Delete(long userid);
    }
}
