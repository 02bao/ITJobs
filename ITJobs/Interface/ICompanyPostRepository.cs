using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface ICompanyPostRepository
    {
        bool CreateNewPost(long companyid, CompanyPost post, DateTime experiation);
        ICollection<CompanyPost> GetAll();
        CompanyPost GetById(long id);
        List<CompanyPost> GetByCompanyId(long companyid);
        bool Update(CompanyPost post, List<IFormFile> images);
        bool Delete(long postid);
    }
}
