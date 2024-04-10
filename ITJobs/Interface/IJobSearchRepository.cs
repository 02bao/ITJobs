using ITJobs.Models;
using System.Runtime.InteropServices.Marshalling;

namespace ITJobs.Interface
{
    public interface IJobSearchRepository
    {
        List<JobSearch> GetJobDesired(long userid, JobDesired job);
        List<CompanyPost> SearchForUser(long userid, JobDesired job);
        ICollection<JobSearch> GetAll();
        JobSearch GetById(long id);

    }
}
