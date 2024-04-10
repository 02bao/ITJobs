using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Models;

namespace ITJobs.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly DataContext _context;

        public JobRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateNewJob(long Companyid, Job_Create jobs, DateTime NewDate)
        {
            var company = _context.Companies.SingleOrDefault( s => s.Id == Companyid );
            if(company == null)
            {
                return false;
            }
            Job job = _context.Jobs.SingleOrDefault( s => s.Companies.Id == Companyid );
            var NewJob = new Job()
            {
                NameJob = jobs.NameJob,
                Position = jobs.Position,
                Location = jobs.Location,
                Salary = jobs.Salary,
                Experience = jobs.Experience,
                Field = jobs.Field,
                Requirements = "",
                Companies = company,
                Deadline = NewDate.ToUniversalTime()
            };
            _context.Jobs.Add( NewJob );
            _context.SaveChanges();
            return true;
        }

        public ICollection<Job> GetAll()
        {
            return _context.Jobs.ToList();
        }

        public Job GetByCompanyId(long companyId)
        {
            throw new NotImplementedException();
        }

        public Job GetById(long id)
        {
            return _context.Jobs.SingleOrDefault(s => s.Id == id);
        }
    }
}
