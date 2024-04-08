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
                WokingMode = post.WokingMode,
                JobField = post.JobField,
                JobStyle = post.JobStyle,
                User = user,
                UserProfiles = userProfiles,
            };
            _context.UserPosts.Add(NewPost);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(long postid)
        {
            var post = _context.UserPosts.SingleOrDefault(s => s.Id ==postid);
            if(post == null)
            {
                return false;
            }
            _context.UserPosts.Remove(post);
            _context.SaveChanges();
            return true;
        }

        public UserPost GetPostById(long postid)
        {
            var post = _context.UserPosts.SingleOrDefault(s => s.Id == postid);
            return post;
        }

        public ICollection<UserPost> GetPosts()
        {
            return _context.UserPosts.ToList();
        }

        public List<UserPost> GetPsotsByUserId(long userId)
        {
            List<UserPost> response = new List<UserPost>();
            var user = _context.UserPosts.Where(s => s.User.Id == userId).ToList();
           
            foreach (var post in user)
            {
                response.Add(new UserPost
                {
                    Id = post.Id,
                    NamePost = post.NamePost,
                    Content = post.Content,
                    Image = post.Image,
                    Timestamp = DateTime.UtcNow,
                    Like = post.Like,
                    Parent = post.Parent,
                    WokingMode = post.WokingMode,
                    JobField = post.JobField,
                    JobStyle = post.JobStyle,
                    Comment = post.Comment,
                });
            }
            return response;
        }

        public bool Update(UserPost post, List<IFormFile> images)
        {
            var userposts = _context.UserPosts.SingleOrDefault(s => s.Id == post.Id); 
            if(userposts == null)
            {
                return false;
            }
            userposts.NamePost = post.NamePost;
            userposts.Content = post.Content;
            userposts.Parent = post.Parent;
            userposts.Comment = post.Comment;
            userposts.Timestamp =DateTime.UtcNow;
            userposts.WokingMode = post.WokingMode;
            userposts.JobField = post.JobField;
            userposts.JobStyle = post.JobStyle;
            userposts.Like = post.Like;
            if(images != null)
            {
                CloudinaryRepository cloudinary = new CloudinaryRepository();
                string imageURL = cloudinary.uploadFile(images[0]);
                if(!string.IsNullOrEmpty(imageURL))
                {
                    userposts.Image = imageURL;
                }
            }
            _context.SaveChanges();
            return true;
        }
    }
}
