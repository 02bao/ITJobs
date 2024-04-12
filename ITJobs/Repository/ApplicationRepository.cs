using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.EntityFrameworkCore;

namespace ITJobs.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly DataContext _context;

        public ApplicationRepository(DataContext context)
        {
            _context = context;
        }
        public bool AddNewApply(long userid, long jobid, long resumeid)
        {
            var user = _context.Users.SingleOrDefault( s => s.Id == userid );
            if(user == null)
            {
                return false;
            }
            var job = _context.Jobs.Include(s => s.Companies).ThenInclude(s => s.Categories).Where(s => s.Id == jobid &&
                                                                s.Categories.Companies.Id == jobid &&
                                                                s.Deadline > DateTime.UtcNow).FirstOrDefault();

            if(job == null)
            {
                return false;
            }
            if(resumeid != null)
            {
                var resumes = _context.Resume.Include( s => s.User).ThenInclude( s => s.UserProfiles)
                                                                    .Where( s => s.Id == resumeid &&
                                                                    s.User.Id == userid &&
                                                                    s.UserProfiles.User.Id == userid).FirstOrDefault();
                if(resumes != null)
                {
                    Application NewApply = new Application()
                    {
                        Users = user,
                        Jobs = job,
                        Resumes = resumes,
                        Letter = "",
                        TimeStamp = DateTime.UtcNow,
                        Status = Status_Apply.Pending,
                    };
                    _context.Applications.Add(NewApply);
                }
                else
                {
                    return false;
                }
            }
            _context.SaveChanges();
            return true;
        }

        public ICollection<Application> GetAll()
        {
            return _context.Applications.ToList();
        }

        public Application GetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
