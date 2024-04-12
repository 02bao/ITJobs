namespace ITJobs.Models
{
    public class Application
    {
        public long Id { get; set; }
        public Job Jobs { get; set; }
        public User Users { get; set; }
        public string Letter { get; set; }
        public Resume Resumes { get; set; }
        public Status_Apply Status { get; set; } = Status_Apply.Pending;
    }

    public enum Status_Apply
    {
        Pending, 
        Accepted,
        Rejected,
    }

    public class Application_Create
    {
        public long Id { get; set; }
        public string Letter { get; set; }
        public Status_Apply Status { get; set; } = Status_Apply.Pending;
    }
}
