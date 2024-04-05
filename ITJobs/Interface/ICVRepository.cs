using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface ICVRepository
    {
        bool CreateNewCV(long userid, CV cV);
        CV GetById(long CvId);
        List<CV> GetByUserId(long UserId);
        ICollection<CV> GetAll();
        bool Update(CV cv);
        bool Delete(long CvId);
    }
}
