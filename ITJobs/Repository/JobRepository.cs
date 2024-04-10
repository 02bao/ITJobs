using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Models;
using System.ComponentModel.Design;

namespace ITJobs.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly DataContext _context;

        public JobRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateNewJob(long Companyid, Job_Create jobs, long categoryid, DateTime NewDate)
        {
            var company = _context.Companies.SingleOrDefault(s => s.Id == Companyid);
            if (company == null)
            {
                return false;
            }
            var categories = _context.Categories.SingleOrDefault( s => s.Id == categoryid);
            if(categories == null)
            {
                return false;
            }
            Job job = _context.Jobs.SingleOrDefault(s => s.Companies.Id == Companyid);
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
                Categories = categories,
                Deadline = NewDate.ToUniversalTime()
            };
            _context.Jobs.Add(NewJob);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var job = _context.Jobs.SingleOrDefault(s => s.Id == id);
            if (job == null)
            {
                return false;
            }
            _context.Jobs.Remove(job);
            _context.SaveChanges();
            return true;
        }

        public ICollection<Job> GetAll()
        {
            return _context.Jobs.ToList();
        }

        public List<Job> GetByCategoryid(long categoryid)
        {
            List<Job> response = new List<Job>();
            var categories = _context.Jobs.Where(s => s.Categories.Id == categoryid).ToList();
            if (categories == null)
            {
                return response;
            }
            foreach (var category in categories)
            {
                response.Add(new Job
                {
                    Id = category.Id,
                    NameJob = category.NameJob,
                    Position = category.Position,
                    Location = category.Location,
                    Salary = category.Salary,
                    Experience = category.Experience,
                    Field = category.Field,
                    Deadline = category.Deadline,
                    Requirements = category.Requirements,
                });
            }
            return response;
        }

        public List<Job> GetByCompanyId(long companyId)
        {
            List<Job> response = new List<Job>();
            var companies = _context.Jobs.Where(s => s.Companies.Id == companyId).ToList();
            if (companies == null)
            {
                return response;
            }
            foreach (var company in companies)
            {
                response.Add(new Job
                {
                    Id = company.Id,
                    NameJob = company.NameJob,
                    Position = company.Position,
                    Location = company.Location,
                    Salary = company.Salary,
                    Experience = company.Experience,
                    Field = company.Field,
                    Deadline = company.Deadline,
                    Requirements = company.Requirements,
                });
            }
            return response;
        }

        public Job GetById(long id)
        {
            return _context.Jobs.SingleOrDefault(s => s.Id == id);
        }

        public bool Update(Job job)
        {
            _context.Jobs.Update(job);
            _context.SaveChanges();
            return true;
        }
    }
}
