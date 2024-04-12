using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface IApplicationRepository
    {
        bool AddNewApply(long userid, long jobid, long resumeid);
        ICollection<Application> GetAll();
        Application GetById(long id);
        List<Application> GetByUserId(long userid);
        bool Update(Application apply);
        bool Delet(long id);

    }
}
