using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface IUserPostRepository
    {
        bool CreateNewPost( long userid, UserPost post );
    }
}
