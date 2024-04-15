using ITJobs.Models;

namespace ITJobs.DTO
{
    public class ConversationDTO
    {
        public long Id { get; set; }
        public DateTime LastTime { get; set; } = DateTime.UtcNow; // thoi gian ket thuc cuoc tro chuyen 
        public Status_Conver Status { get; set; } = Status_Conver.Active;
    }
    public class Conversation_GetDTO
    {
        public long Id { get; set; }
        public List<Message_Get> Messages { get; set; }
        public Status_Conver Status { get; set; } = Status_Conver.Active;
        public DateTime? LastTime { get; set; } = DateTime.UtcNow; // thoi gian ket thuc cuoc tro chuyen 
    }
}
