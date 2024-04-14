namespace ITJobs.Models
{
    public class Job
    {
        public long Id { get; set; }
        public  Company? Companies { get; set; }
        public  Category? Categories { get; set; }
        public required string NameJob { get; set; }
        public required string Location { get; set; }
        public required string Position { get; set; }
        public required string Salary { get; set; }
        public required string Experience { get; set; }
        public required string Field { get; set; }
        public string? Requirements { get; set; }
        public DateTime Deadline { get; set; } = DateTime.UtcNow;
    }

    public class Job_Create
    {
        public required string NameJob { get; set; }
        public required string Location { get; set; }
        public required string Position { get; set; }
        public required string Salary { get; set; }
        public required string Experience { get; set; }
        public required string Field { get; set; }
        public DateTime Deadline { get; set; } = DateTime.UtcNow;
    }

}
