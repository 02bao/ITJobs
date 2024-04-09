using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface IJobSearchRepository
    {
        List<JobSearch> GetJobDesired(long userid, JobDesired job);
        List<CompanyPost> JobSearch(long userid, JobDesired job);
    }
}
