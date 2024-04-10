using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface IJobRepository
    {
        bool CreateNewJob(long Companyid, Job_Create job, DateTime NewDate);
        ICollection<Job> GetAll();
        Job GetById(long id);
        List<Job> GetByCompanyId(long companyId);
        bool Update(Job job);
        bool Delete(long id);
    }
}
