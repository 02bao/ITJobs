using ITJobs.Models;

namespace ITJobs.DTO
{
    public class UserPostDTO
    {
        public long Id { get; set; }
        public required string NamePost { get; set; }
        public required string Content { get; set; }
        public string? Image { get; set; }
        public DateTime? Timestamp { get; set; } = DateTime.UtcNow;
        public long? Like { get; set; }
        public int Parent { get; set; }
        public required string WokingMode { get; set; }
        public required string JobStyle { get; set; }
        public required string JobField { get; set; }
        public List<string>? Comment { get; set; }
    }
}
