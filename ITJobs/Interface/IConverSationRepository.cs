using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface IConverSationRepository
    {
        Conversation CreateNewConverByUserId(long UserId, string CompanyName, string Subject, string Contents);

    }
}
