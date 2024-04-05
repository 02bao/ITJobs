namespace ITJobs.Models
{
    public class CV
    {
        public long Id { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Experience { get; set; }
        public string Educartion { get; set; }
        public string Certifications { get; set; }
        public UserProfiles UserProfiles { get; set; }
    }
}
