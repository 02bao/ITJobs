using ITJobs.Models;

namespace ITJobs.DTO;

public class MessageDTO
{
    public long Id { get; set; }
    public string? SenderName { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow; // thoi gian bat dau cuoc tro chuyen
    public string URL { get; set; } = string.Empty;
}
public class Message_GetDTO
{
    public string SenderName { get; set; } //ten cua doi tuong gui
    public string Content { get; set; } = string.Empty;
    public DateTime? Timestamp { get; set; } = DateTime.UtcNow; // thoi gian bat dau cuoc tro chuyen
    public string URL { get; set; } = "";
}
