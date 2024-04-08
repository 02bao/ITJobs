﻿namespace ITJobs.Models
{
    public class UserPost
    {
        public long Id { get; set; }
        public User User { get; set; }
        public string NamePost { get; set; }
        public string Content { get; set; }
        public string? Image { get; set; }
        public DateTime? Timestamp { get; set; } = DateTime.UtcNow;
        public UserProfiles UserProfiles { get; set; }
        public long? Like { get; set; }
        public int Parent { get; set; }
        public string WokingMode { get; set; }
        public string JobStyle { get; set; }
        public string JobField { get; set; }
        public List<string>? Comment { get; set; }
    }
}
