using ITJobs.Models;

namespace ITJobs.DTO
{
    public class ApplicationDTO
    {
        public long Id { get; set; }
        public string Letter { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public Status_Apply Status_ { get; set; } = Status_Apply.Unsent;
    }
    public enum Status_Apply
    {
        Unsent,
        Pending,
        Accepted,
        Rejected,
    }
}
