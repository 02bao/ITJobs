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

        public ICollection<CompanyPost> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<CompanyPost> GetByCompanyId(long companyid)
        {
            throw new NotImplementedException();
        }

        public CompanyPost GetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
