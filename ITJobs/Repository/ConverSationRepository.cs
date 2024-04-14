using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Models;

namespace ITJobs.Repository
{
    public class ConverSationRepository(DataContext _context) : IConverSationRepository
    {
        public Conversation CreateNewConverByUserId(long UserId, string CompanyName, string Subject, string Contents)
        {
            Company companies = _context.Companies.SingleOrDefault(s => s.Name == CompanyName);
            if(companies == null) { return null; }
            User users = _context.Users.SingleOrDefault(s => s.Id == UserId);
            var ExistConver = _context.Conversations.SingleOrDefault(
                                                     s => s.Users.Id == UserId &&
                                                     s.Companies.Name == CompanyName);
            if(ExistConver != null) // Neu da ton tai cuoc tro chuyen cu
            {   //Add tin nhan moi vao cuoc tro chuyen cu 
                ExistConver.Messages.Add(
                    new Message
                    {
                        SenderId = UserId,
                        Content  = Contents,
                        Timestamp = DateTime.UtcNow
                });
                 ExistConver.LastTime = DateTime.UtcNow;
                _context.SaveChanges();
                return ExistConver;
            }
            Conversation NewConver = new Conversation()
            {
                Users = users,
                Companies = companies,
                LastTime = DateTime.UtcNow,
                Status = Status_Conver.Active,
                Messages = new List<Message>()
                {
                    new Message
                    {
                        SenderId = UserId,
                        Content = Contents,
                        Timestamp = DateTime.UtcNow
                    }
                }
            };
            _context.Conversations.Add(NewConver);
            _context.SaveChanges();
            return NewConver;
        }
    }
}
