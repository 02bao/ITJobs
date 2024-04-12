using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Models;

namespace ITJobs.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly DataContext _context;

        public ApplicationRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateNewApply(long userid, long companyid, Application_Create apply)
        {
        }
    }
}
