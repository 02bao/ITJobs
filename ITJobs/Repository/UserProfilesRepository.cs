using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Models;

namespace ITJobs.Repository
{
    public class UserProfilesRepository : IUserProfilesRepository
    {
        private readonly DataContext _context;

        public UserProfilesRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateUserProfiles(long userid, UserProfiles users)
        {
            User user = _context.Users.SingleOrDefault(s => s.Id == userid);
            if(user == null)
            {
                return false;
            }
            var NewProfile = new UserProfiles()
            {
                FullName = users.FullName,
                Phone = users.Phone,
                Address = users.Address,
                Avatar ="",
                User = user,
            };
            _context.UserProfiles.Add(NewProfile);
            _context.SaveChanges();
            return true;
        }
    }
}
