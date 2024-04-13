using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface INotificationRepository
    {
        bool CreateNewNoti(long userid, long companyid, long applied, Status_Noti status);
        ICollection<Notification> GetAll();
        Notification GetById(long id);
        List<Notification> GetByUserid(long userId);
        bool Update(Notification noti);
        bool Deleted(long id);
    }
}
