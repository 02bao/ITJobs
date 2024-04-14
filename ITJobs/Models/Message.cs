namespace ITJobs.Models
{
    public class Message
    {
        public long Id { get; set; }
        public Conversation? Conversations { get; set; }
        public long SenderId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow; // thoi gian bat dau cuoc tro chuyen
        public string URL { get; set; } = string.Empty;
    }
}
