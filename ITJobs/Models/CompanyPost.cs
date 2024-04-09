namespace ITJobs.Models
{
    public class CompanyPost
    {
        public long Id { get; set; }
        public Company Companies { get; set; }
        public string NamePost { get; set; }
        public string Content { get; set; }
        public string? Image { get; set; }
        public int? Like { get; set; }
        public int Parent { get; set; }
        public List<string>? Comment { get; set; }
        public DateTime? Timestamp { get; set; } = DateTime.UtcNow;
        public DateTime? ExpirationDate { get; set; } = DateTime.UtcNow;
        public string Salary { get; set; }
        public int? ApplicationCount { get; set; }
        public string WorkingMode { get; set; }
        public string JobStyle { get; set; }
        public string Field { get; set; }

    }

    public class CompanyPost_Create
    {
        public string NamePost { get; set; }
        public string Content { get; set; }
        public int Parent { get; set; }
        public DateTime? Timestamp { get; set; } = DateTime.UtcNow;
        public DateTime? ExpirationDate { get; set; } = DateTime.UtcNow;
        public string Salary { get; set; }
        public string WorkingMode { get; set; }
        public string JobStyle { get; set; }
        public string Field { get; set; }
    }
}
