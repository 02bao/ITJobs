using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Models;

namespace ITJobs.Repository
{
    public class CompanyPostRepository : ICompanyPostRepository
    {
        private readonly DataContext _context;

        public CompanyPostRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateNewPost(long companyid, CompanyPost post, DateTime experiation)
        {
            var company = _context.Companies.SingleOrDefault(s => s.Id == companyid);
            if(company == null)
            {
                return false;
            }
            var NewPost = new CompanyPost
            {
                NamePost = post.NamePost,
                Content = post.Content,
                Image = post.Image,
                Like = post.Like,
                Parent = post.Parent,
                Comment = post.Comment,
                Timestamp = DateTime.UtcNow,
                ExpirationDate = experiation.ToUniversalTime(),
                ApplicationCount = post.ApplicationCount,
                Salary = post.Salary,
                WorkingMode = post.WorkingMode,
                Field = post.Field,
                JobStyle = post.JobStyle,
                Companies = company,
            };
            _context.CompanyPosts.Add(NewPost);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(long postid)
        {
            var post = _context.CompanyPosts.SingleOrDefault(s => s.Id == postid);
            if(post == null)
            {
                return false;
            }
            _context.CompanyPosts.Remove(post);
            _context.SaveChanges();
            return true;
        }

        public ICollection<CompanyPost> GetAll()
        {
            return _context.CompanyPosts.ToList();
        }

        public List<CompanyPost> GetByCompanyId(long companyid)
        {
            List<CompanyPost> response = new List<CompanyPost>();
            var companies = _context.CompanyPosts.Where(s => s.Companies.Id == companyid).ToList();
            foreach ( var company in companies)
            {
                response.Add(new CompanyPost
                {
                    Id = company.Id,
                    NamePost = company.NamePost,
                    Content = company.Content,
                    Image = company.Image,
                    Like = company.Like,
                    Parent = company.Parent,
                    Comment = company.Comment,
                    Timestamp = company.Timestamp,
                    ExpirationDate = company.ExpirationDate,
                    ApplicationCount = company.ApplicationCount,
                    Salary = company.Salary,
                    WorkingMode = company.WorkingMode,
                    Field = company.Field,
                    JobStyle = company.JobStyle,
                });
            }
            return response;
        }

        public CompanyPost GetById(long id)
        {
            var post = _context.CompanyPosts.SingleOrDefault(s => s.Id == id);
            return post;
        }

        public bool Update(CompanyPost post, List<IFormFile> images)
        {
            var NewDate = DateTime.Parse(post.ExpirationDate.ToString()).ToUniversalTime();
            var postid = _context.CompanyPosts.SingleOrDefault(s => s.Id == post.Id);
            if(postid == null)
            {
                return false;
            }
            postid.NamePost = post.NamePost;
            postid.Content = post.Content;
            postid.Like = post.Like;
            postid.Parent = post.Parent;
            postid.Comment = post.Comment;
            postid.Timestamp = DateTime.UtcNow;
            postid.ExpirationDate = NewDate;
            postid.ApplicationCount = post.ApplicationCount;
            postid.Salary = post.Salary;
            postid.WorkingMode = post.WorkingMode;
            postid.Field = post.Field;
            postid.JobStyle = post.JobStyle;
            if(images != null)
            {
                CloudinaryRepository cloudinary = new CloudinaryRepository();
                string imageURL = cloudinary.uploadFile(images[0]);
                if(!string.IsNullOrEmpty(imageURL))
                {
                    postid.Image = imageURL;
                }
            }
            _context.SaveChanges();
            return true;
        }
    }
}
