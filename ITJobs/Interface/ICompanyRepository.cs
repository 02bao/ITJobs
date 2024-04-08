using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface ICompanyRepository
    {
        bool CreateNewCompany(Company company, long userid);
        ICollection<Company> GetAll();
        Company GetById(long companyid);
        User GetByUserId(long userId);
    }
}
