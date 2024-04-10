using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface IJobRepository
    {
        bool CreateNewJob(long Companyid, Job_Create job, DateTime NewDate);
    }
}
