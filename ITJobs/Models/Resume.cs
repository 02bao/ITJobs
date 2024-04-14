namespace ITJobs.Models
{
    public class Resume
    {
        public long Id { get; set; }
        public   User? User { get; set; }
        public required string Title { get; set; }
        public required string Experience { get; set; }
        public required string Educartion { get; set; }
        public required string Skill { get; set; }
        public required string Certifications { get; set; }
        public List<string>? GitHubRepository { get; set; }
        public  UserProfiles? UserProfiles { get; set; }
    }

    public class Resume_create
    {
        public required string Title { get; set; }
        public required string Experience { get; set; }
        public required string Educartion { get; set; }
        public required string Skill { get; set; }
        public required string Certifications { get; set; }
    }
}
