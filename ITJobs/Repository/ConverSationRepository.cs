using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ITJobs.Repository
{
    public class ConverSationRepository(DataContext _context) : IConverSationRepository
    {
        public bool CreateNewConverByCompany(long Companied, string UserName, string Contents)
        {
            User user = _context.Users.SingleOrDefault(x => x.UserName == UserName);
            if (user == null) { return false; }
            Company company = _context.Companies.SingleOrDefault(s => s.Id == Companied);
            if (company == null) { return false; }
            var ExistConver = _context.Conversations.Include(s => s.Messages).Where(
                                                           x => x.Company.Id == Companied &&
                                                           x.User.UserName == UserName).FirstOrDefault();
            if (ExistConver != null)
            {
                ExistConver.Messages.Add(new Message()
                {
                    SenderName = company.Name,
                    Content = Contents,
                    Timestamp = DateTime.UtcNow,
                    URL = "",
                    Conversations = ExistConver,
                });

                ExistConver.LastTime = DateTime.UtcNow;
                ExistConver.Status = Status_Conver.Active;
                _context.SaveChanges();
                return true;

            }
            Conversation NewConver = new Conversation()
            {
                User = user,
                Company = company,
                LastTime = DateTime.UtcNow,
                Status = Status_Conver.Active,
                Messages = new List<Message>()
                {
                    new Message
                    {
                        SenderName = company.Name,
                        Content = Contents,
                        Timestamp = DateTime.UtcNow,
                        URL="",
                    }
                }
            };
            _context.Conversations.Add(NewConver);
            _context.SaveChanges();
            return true;
        }
        public bool CreateNewConverByUser(long UserId, string CompanyName, string Contents)
        {
            User user = _context.Users.SingleOrDefault(x => x.Id == UserId);
            if (user == null) { return false; }
            Company company = _context.Companies.SingleOrDefault( s => s.Name == CompanyName );
            if (company == null) { return false; }
            var ExistConver = _context.Conversations.Include(s => s.Messages).Where( 
                                                           x => x.User.Id == UserId &&
                                                           x.Company.Name == CompanyName).FirstOrDefault();
            if(ExistConver != null)
            {
                ExistConver.Messages.Add(new Message()
                    {
                        SenderName = user.UserName,
                        Content = Contents,
                        Timestamp = DateTime.UtcNow,
                        URL = "",
                        Conversations = ExistConver,
                    });
                
                ExistConver.LastTime = DateTime.UtcNow;
                ExistConver.Status = Status_Conver.Active;
                _context.SaveChanges();
                return true;
                
            }
            Conversation NewConver = new Conversation()
            {
                User = user,
                Company = company,
                LastTime = DateTime.UtcNow,
                Status = Status_Conver.Active,
                Messages = new List<Message>()
                {
                    new Message
                    {
                        SenderName = user.UserName,
                        Content = Contents,
                        Timestamp = DateTime.UtcNow,
                        URL="",
                    }
                }
            };
            _context.Conversations.Add(NewConver);
            _context.SaveChanges();
            return true;
        }
    }
}
