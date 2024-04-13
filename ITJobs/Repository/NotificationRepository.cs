using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.EntityFrameworkCore;

namespace ITJobs.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly DataContext _context;

        public NotificationRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateNewNoti(long userid, long companyid, Noti_Create noti)
        {
            var user = _context.Users.SingleOrDefault( s => s.Id == userid );
            if (user == null)
            {
                return false;
            }
            var companies = _context.Companies.SingleOrDefault( c => c.Id == companyid );
            if (companies == null)
            {
                return false;
            }
            var applycation = _context.Applications.Include( s => s.Users)
                                                    .Include(s => s.Jobs).ThenInclude(s => s.Companies)
                                                    .Where( s => s.Users.Id == userid && 
                                                    s.Jobs.Companies.Id == companyid &&
                                                    s.TimeStamp < DateTime.UtcNow).FirstOrDefault();
            if (applycation != null)
            {
                var NewNoti = new Notification()
                {
                    Content = noti.Content,
                    Timestamp = DateTime.UtcNow,
                    ReadStatus = false,
                    Status = noti.Status,
                };
                _context.Notifications.Add(NewNoti);
            }
            _context.SaveChanges();
            return true;
        }
    }
}
