namespace ITJobs.Models
{
    public class Application
    {
        public long Id { get; set; }
        public required Job Jobs { get; set; }
        public required User Users { get; set; }
        public string? Letter { get; set; }
        public Resume? Resumes { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public Status_Apply Status { get; set; } = Status_Apply.Unsent;
    }

    public enum Status_Apply
    {
        Unsent,
        Pending, 
        Accepted,
        Rejected,
    }

    
}
