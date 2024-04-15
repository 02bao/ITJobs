using System.Text.Json.Serialization;

namespace ITJobs.Models;

public class Conversation
{
    public long Id { get; set; }
    public User? User { get; set; }
    public Company? Company { get; set; }
    public List<Message>? Messages { get; set; }
    public DateTime? LastTime { get; set; } = DateTime.UtcNow; // thoi gian ket thuc cuoc tro chuyen 
    public Status_Conver Status { get; set; } = Status_Conver.Active;
}
public enum Status_Conver
{
    Active,
    Close,
    Pending
}

public class Conversation_Create
{
    public List<Message_Create> Messages { get; set; }
    public Status_Conver Status { get; set; } = Status_Conver.Active;
    public DateTime LastTime { get; set; } = DateTime.UtcNow; // thoi gian ket thuc cuoc tro chuyen 
}
