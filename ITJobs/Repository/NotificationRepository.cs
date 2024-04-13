using ITJobs.Data;
using ITJobs.Interface;

namespace ITJobs.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly DataContext _context;

        public NotificationRepository(DataContext context)
        {
            _context = context;
        }
    }
}
