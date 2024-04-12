using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface IApplicationRepository
    {
        bool AddNewApply(long userid, long jobid, long resumeid);
    }
}
