using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Models;

namespace ITJobs.Repository
{
    public class UserPostRepository : IUserPostRepository
    {
        private readonly DataContext _context;

        public UserPostRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateNewPost(long userid, UserPost post)
        {
            User user = _context.Users.SingleOrDefault( s => s.Id == userid );
            if(user == null)
            {
                return false;
            }
            UserProfiles userProfiles = _context.UserProfiles.SingleOrDefault( s => s.User.Id ==  userid );
            var NewPost = new UserPost()
            {
                NamePost = post.NamePost,
                Content = post.Content,
                Image = post.Image,
                Timestamp = DateTime.UtcNow,
                Like = post.Like,
                Parent = post.Parent,
                Comment = post.Comment,
                User = user,
                UserProfiles = userProfiles,
            };
            _context.UserPosts.Add(NewPost);
            _context.SaveChanges();
            return true;
        }

        public UserPost GetPostById(long postid)
        {
            throw new NotImplementedException();
        }

        public ICollection<UserPost> GetPosts()
        {
            return _context.UserPosts.ToList();
        }

        public List<UserPost> GetPsotsByUserId(long userId)
        {
            throw new NotImplementedException();
        }
    }
}
