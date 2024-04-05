using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Models;

namespace ITJobs.Repository
{
    public class ResumeRepository : IResumeRepository
    {
        private readonly DataContext _context;

        public ResumeRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateNewCV(long userid, Resume cv)
        {
            User user = _context.Users.SingleOrDefault( s=> s.Id == userid );
            if(user == null)
            {
                return false;
            }
            UserProfiles userprofiles = _context.UserProfiles.SingleOrDefault( s=> s.User.Id ==  userid );
            Resume NewCV = new Resume()
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
            _context.Resume.Add( NewCV );
            _context.SaveChanges();
            return true;
        }

        public bool Delete(long CvId)
        {
            Resume cvs = _context.Resume.SingleOrDefault(s => s.Id ==  CvId);
            if(cvs == null)
            {
                return false;
            }
            _context.Resume.Remove( cvs );
            _context.SaveChanges();
            return true;
        }

        public ICollection<Resume> GetAll()
        {
            return _context.Resume.ToList();
        }

        public Resume GetById(long CvId)
        {
            return _context.Resume.SingleOrDefault(s => s.Id == CvId);
        }

        public List<Resume> GetByUserId(long UserId)
        {
            List<Resume> response = new List<Resume>();
            var users = _context.Resume.Where(s => s.User.Id ==  UserId).ToList();
            if(users == null)
            {
                return response;
            }
            foreach( var user in users )
            {
                response.Add(new Resume()
                {
                    Id = user.Id,
                    Title=user.Title,
                    Experience=user.Experience,
                    Skill=user.Skill,
                    GitHubRepository=user.GitHubRepository,
                    Certifications=user.Certifications,
                    Educartion=user.Educartion,
                });
            }
            return response;
        }

        public bool Update(Resume cv)
        {
            var cvs = _context.Resume.SingleOrDefault(s => s.Id == cv.Id);
            if(cvs == null)
            {
                return false;
            }
            cvs.Title = cv.Title;
            cvs.Educartion = cv.Educartion;
            cvs.Certifications = cv.Certifications;
            cvs.Experience = cv.Experience;
            cvs.Skill = cv.Skill;
            cvs.GitHubRepository = cv.GitHubRepository;
            _context.SaveChanges();
            return true;
        }
    }
}
