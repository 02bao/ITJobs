namespace ITJobs.Models
{
    public class Resume
    {
        public long Id { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Experience { get; set; }
        public string Educartion { get; set; }
        public string Skill { get; set; }
        public string Certifications { get; set; }
        public List<string>? GitHubRepository { get; set; }
        public UserProfiles UserProfiles { get; set; }
    }
}
