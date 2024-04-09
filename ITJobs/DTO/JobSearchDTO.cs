using ITJobs.Models;

namespace ITJobs.DTO
{
    public class JobSearchDTO
    {
        public long Id { get; set; }
        public string Position { get; set; }
        public string Location { get; set; }
        public string? Salary_Range { get; set; }
        public string? Experience_Level { get; set; }
        public string? Filed { get; set; }
        public DateTime? Timestamp { get; set; } = DateTime.UtcNow;
    }
}
