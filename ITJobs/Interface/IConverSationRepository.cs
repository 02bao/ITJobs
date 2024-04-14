using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface IConverSationRepository
    {
        Conversation_Create CreateNewConverByUserId(long UserId, string CompanyName, string Contents);

    }
}
