using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.EntityFrameworkCore;

namespace ITJobs.Repository;

public class NotificationRepository(DataContext _context) : INotificationRepository
{
    public bool CreateNewNoti(long userid, long companyid, long applied, Status_Noti status)
    {
        var user = _context.Users.SingleOrDefault( s => s.Id == userid );
        if (user == null)
        {
            return false;
        }
        var companies = _context.Companies.Include( s => s.User)
                                          .Where( c => c.Id == companyid &&
                                           c.User.Id != userid).FirstOrDefault();
        if (companies == null)
        {
            return false;
        }
        var applycation = _context.Applications.Include( s => s.Users)
                                                .Include(s => s.Jobs).ThenInclude(s => s.Companies)
                                                .Where(s =>  s.Id == applied &&
                                                 s.Users.Id == userid && 
                                                 s.Jobs.Companies.Id == companyid &&
                                                 s.TimeStamp < DateTime.UtcNow).FirstOrDefault();
        if (applycation != null)
        {
            Notification NewNoti = new Notification()
            {
                Users = user,
                Companies = companies,
                Applications = applycation,
                Applied = applycation.Id,
                Content = "",
                Timestamp = DateTime.UtcNow,
                ReadStatus = false,
                Status = status,
            };
            _context.Notifications.Add(NewNoti);
        }
        _context.SaveChanges();
        return true;
    }

    public bool Deleted(long id)
    {
        var notid = _context.Notifications.SingleOrDefault( s => s.Id == id);
        if (notid == null)
        {
            return false;
        }
        _context.Notifications.Remove(notid);
        _context.SaveChanges();
        return true;
    }

    public ICollection<Notification> GetAll()
    {
        return _context.Notifications.ToList();
    }

    public Notification GetById(long id)
    {
        return _context.Notifications.SingleOrDefault(s => s.Id == id);
    }

    public List<Notification> GetByUserid(long userId)
    {
        List<Notification> list = new List<Notification>();
        var user = _context.Notifications.Where(s => s.Users.Id == userId).ToList();
        if(user == null)
        {
            return list;
        }
        foreach(var item in user)
        {
            list.Add(new Notification()
            {
                Id = item.Id,
                Applied = item.Applied,
                Status = item.Status,
                Content = item.Content,
                ReadStatus=item.ReadStatus,
            });
        }
        return list;
    }

    public bool Update(Notification noti)
    {
        _context.Notifications.Update(noti);
        _context.SaveChanges();
        return true;
    }
}
