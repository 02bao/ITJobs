using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Models;

namespace ITJobs.Repository
{
    public class ConverSationRepository(DataContext _context) : IConverSationRepository
    {
        public Conversation_Create CreateNewConverByUserId(long UserId, string CompanyName, string Contents)
        {
            Conversation_Create NewConver = new Conversation_Create();
            List<Message_Create> NewMessage = new List<Message_Create>();
            Company companies = _context.Companies.SingleOrDefault(s => s.Name == CompanyName);
            if(companies == null) { return null; }
            User users = _context.Users.SingleOrDefault(s => s.Id == UserId);
            var ExistConver = _context.Conversations.SingleOrDefault(
                                                     s => s.Users.Id == UserId &&
                                                     s.Companies.Name == CompanyName);
            if(ExistConver != null) // Neu da ton tai cuoc tro chuyen cu
            {   //Add tin nhan moi vao cuoc tro chuyen cu 
                List<Message> Messages = ExistConver.Messages;
                foreach(Message messages in Messages)
                {
                    Message_Create message = new Message_Create()
                    {
                        SenderName = messages.SenderName,
                        Content = Contents,
                        URL = messages.URL,
                        Timestamp = DateTime.UtcNow,
                    };
                    NewMessage.Add(message);
                }
                
                NewConver.Messages = NewMessage.ToList();
                return NewConver;
            }
            Message_Create NewMessages = new Message_Create()
            {
                SenderName = users.UserName,
                Content = Contents,
                URL = "",
                Timestamp = DateTime.UtcNow,
            };
            NewConver.Messages = NewMessage;
            NewConver.Messages.Add(NewMessages);
            NewConver.Status = Status_Conver.Active;
            NewConver.LastTime = DateTime.UtcNow;
            return NewConver;
        }
    }
}
