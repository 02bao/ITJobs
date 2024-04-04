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

        public ICollection<UserProfiles> GetAll()
        {
            return _context.UserProfiles.ToList();
        }

        public UserProfiles GetById(long userprofileId)
        {
            return _context.UserProfiles.SingleOrDefault(s => s.Id == userprofileId);
        }

        public List<UserProfiles> GetByUserId(long userId)
        {
            List<UserProfiles> response = new List<UserProfiles>();
            var users = _context.UserProfiles.Where(s => s.User.Id == userId).ToList();
            foreach( var profile in users)
            {
                response.Add(new UserProfiles
                {
                    Id = profile.Id,
                    FullName = profile.FullName,
                    Phone = profile.Phone,
                    Address = profile.Address,
                    Avatar = profile.Avatar,
                });
            }
            return response;
        }

        public bool Update(UserProfiles userprofile, IFormFile avaterfile)
        {
            var users = _context.UserProfiles.SingleOrDefault( s=> s.Id == userprofile.Id);
            if(users == null)
            {
                return false;
            }
            users.FullName = userprofile.FullName;
            users.Phone = userprofile.Phone;
            users.Address = userprofile.Address;
            if (users.Avatar.Any())
            {
                CloudinaryRepository cloudinary = new CloudinaryRepository();
                string imageUrl = cloudinary.uploadImage(avaterfile).Result;
                if(!string.IsNullOrEmpty(imageUrl))
                {
                    users.Avatar = imageUrl;
                }
            }
            _context.SaveChanges();
            return true;
        }
    }
}
