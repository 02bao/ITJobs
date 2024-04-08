using ITJobs.Models;

namespace ITJobs.DTO
{
    public class UserPostDTO
    {
        public long Id { get; set; }
        public string NamePost { get; set; }
        public string Content { get; set; }
        public string? Image { get; set; }
        public DateTime? Timestamp { get; set; } = DateTime.UtcNow;
        public long? Like { get; set; }
        public int Parent { get; set; }
        public string WokingMode { get; set; }
        public string JobStyle { get; set; }
        public string JobField { get; set; }
        public List<string>? Comment { get; set; }
    }
}
