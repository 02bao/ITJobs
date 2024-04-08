using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface IUserPostRepository
    {
        bool CreateNewPost( long userid, UserPost post );
        ICollection<UserPost> GetPosts();
        UserPost GetPostById( long postid );
        List<UserPost> GetPsotsByUserId( long userId );
        bool Update( UserPost post , List<IFormFile> images);
        bool Delete( long postid );
    }
}
