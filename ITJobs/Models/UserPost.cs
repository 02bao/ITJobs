namespace ITJobs.Models
{
    public class UserPost
    {
        public long Id { get; set; }
        public  User? User { get; set; }
        public required string NamePost { get; set; }
        public string Content { get; set; } = string.Empty;
        public string? Image { get; set; }
        public DateTime? Timestamp { get; set; } = DateTime.UtcNow;
        public UserProfiles? UserProfiles { get; set; }
        public long? Like { get; set; }
        public int Parent { get; set; }
        public required string WokingMode { get; set; }
        public required string JobStyle { get; set; }
        public required string JobField { get; set; }
        public List<string>? Comment { get; set; }
    }

    public class UserPost_Create
    {
        public required string NamePost { get; set; }
        public required string Content { get; set; }
        public string? Image { get; set; }
        public DateTime? Timestamp { get; set; } = DateTime.UtcNow;
        public int Parent { get; set; }
        public required string WokingMode { get; set; }
        public required string JobStyle { get; set; }
        public required string JobField { get; set; }
    }
}
