namespace ITJobs.Models
{
    public class JobSearch
    {
        public long Id { get; set; }
        public User? Users { get; set; }
        public Company? Companies { get; set; }
        public required string Position { get; set; }
        public required string Location { get; set; }
        public string? Salary_Range { get; set; }
        public string? Experience_Level { get; set; }
        public string? Filed { get; set; }
        public DateTime? Timestamp { get; set; } = DateTime.UtcNow;
    }

    public class JobDesired
    {
        public required string Position { get; set; }
        public required string Location { get; set; }
        public string? Salary_Range { get; set; }
        public string? Experience_Level { get; set; }
        public string? Filed { get; set; }
        public DateTime? Timestamp { get; set; } = DateTime.UtcNow;
    }
}
