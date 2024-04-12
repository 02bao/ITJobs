using ITJobs.Models;

namespace ITJobs.DTO
{
    public class ApplicationDTO
    {
        public long Id { get; set; }
        public string Letter { get; set; }
        public Status_Apply Status_ { get; set; } = Status_Apply.Pending;
    }
}
