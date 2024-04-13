using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface INotificationRepository
    {
        bool CreateNewNoti(long userid, long companyid, long applied, Status_Noti status);
    }
}
