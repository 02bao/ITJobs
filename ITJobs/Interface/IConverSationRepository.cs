using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface IConverSationRepository
    {
        bool CreateNewConverByUser(long UserId, string CompanyName, string Contents);
        bool CreateNewConverByCompany(long Companied, string UserName, string Contents);
    }
}
