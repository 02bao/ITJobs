using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface ICompanyRepository
    {
        bool CreateNewCompany(Company company, long userid);
        ICollection<Company> GetAll();
        Company GetById(long companyid);
        List<Company> GetByUserId(long userId);
        bool ChangeInformation(Company companyid);
        bool Delete (long  companyid);
    }
}
