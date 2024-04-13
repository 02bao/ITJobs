using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface INotificationRepository
    {
        bool CreateNewNoti(long userid, long companyid, Noti_Create noti);
    }
}
