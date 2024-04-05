using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface ICVRepository
    {
        bool CreateNewCV(long userid, CV cV);
    }
}
