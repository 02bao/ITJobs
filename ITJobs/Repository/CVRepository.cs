using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Models;

namespace ITJobs.Repository
{
    public class CVRepository : ICVRepository
    {
        private readonly DataContext _context;

        public CVRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateNewCV(long userid, CV cv)
        {
            User user = _context.Users.SingleOrDefault( s=> s.Id == userid );
            if(user == null)
            {
                return false;
            }
            UserProfiles userprofiles = _context.UserProfiles.SingleOrDefault( s=> s.User.Id ==  userid );
            CV NewCV = new CV()
            {
                Title = cv.Title,
                Educartion = cv.Educartion,
                Certifications = cv.Certifications,
                Experience = cv.Experience,
                Skill = cv.Skill,
                GitHubRepository = null,
                User = user,
                UserProfiles = userprofiles,
            };
            _context.Cv.Add( NewCV );
            _context.SaveChanges();
            return true;
        }
    }
}
