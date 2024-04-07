using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface ICompanyRepository
    {
        bool CreateNewCompany(Company company, long userid);
    }
}
