using ITJobs.Models;

namespace ITJobs.DTO
{
    public class ResumeDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Experience { get; set; }
        public string Educartion { get; set; }
        public string Certifications { get; set; }
        public string Skill { get; set; }
        public List<string>? GitHubRepository { get; set; }
    }
}
