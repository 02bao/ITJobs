using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface IApplicationRepository
    {
        bool CreateNewApply(long userid, long companyid, Application_Create apply);
    }
}
