using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface IResumeRepository
    {
        bool CreateNewCV(long userid, Resume cV);
        Resume GetById(long CvId);
        List<Resume> GetByUserId(long UserId);
        ICollection<Resume> GetAll();
        bool Update(Resume cv);
        bool Delete(long CvId);
    }
}
