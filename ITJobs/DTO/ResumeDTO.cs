using ITJobs.Models;

namespace ITJobs.DTO
{
    public class ResumeDTO
    {
        public long Id { get; set; }
        public required string Title { get; set; }
        public required string Experience { get; set; }
        public required string Educartion { get; set; }
        public required string Certifications { get; set; }
        public required string Skill { get; set; }
        public List<string>? GitHubRepository { get; set; }
    }
}
