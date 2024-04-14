using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Models;

namespace ITJobs.Repository
{
    public class CompanyPostRepository(DataContext _context) : ICompanyPostRepository
    {
        public bool CreateNewPost(long companyid, CompanyPost_Create post, DateTime experiation)
        {
            var company = _context.Companies.SingleOrDefault(s => s.Id == companyid);
            if (company == null)
            {
                return false;
            }
            var NewPost = new CompanyPost
            {
                NamePost = post.NamePost,
                Location = post.Location,
                Position = post.Position,
                Content = post.Content,
                Image = null,
                Like = null,
                Parent = post.Parent,
                Comment = null,
                Timestamp = DateTime.UtcNow,
                ExpirationDate = experiation.ToUniversalTime(),
                ApplicationCount = null,
                Salary = post.Salary,
                WorkingMode = post.WorkingMode,
                Field = post.Field,
                Experience = post.Experience,
                Companies = company,
            };
            _context.CompanyPosts.Add(NewPost);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(long postid)
        {
            var post = _context.CompanyPosts.SingleOrDefault(s => s.Id == postid);
            if (post == null)
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
            List<CompanyPost> response = new();
            var companies = _context.CompanyPosts.Where(s => s.Companies.Id == companyid).ToList();
            foreach (var company in companies)
            {
                response.Add(new CompanyPost
                {
                    Id = company.Id,
                    NamePost = company.NamePost,
                    Location = company.Location,
                    Position = company.Position,
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
                    Experience = company.Experience,
                });
                // sao ở đây không dùng mapper z anh
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
            if (postid == null)
            {
                return false;
            }
            postid.NamePost = post.NamePost;
            postid.Location = post.Location;
            postid.Position = post.Position;
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
            postid.Experience = post.Experience;
            if (images != null)
            {
                CloudinaryRepository cloudinary = new();
                string imageURL = cloudinary.uploadFile(images[0]);
                if (!string.IsNullOrEmpty(imageURL))
                {
                    postid.Image = imageURL;
                }
            }
            _context.SaveChanges();
            return true;
        }
    }
}
