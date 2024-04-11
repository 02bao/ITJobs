namespace ITJobs.Models
{
    public class Application
    {
        public long Id { get; set; }
        public Job Jobs { get; set; }
        public User Users { get; set; }
    }
}
