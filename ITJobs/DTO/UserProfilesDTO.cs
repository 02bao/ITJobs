using ITJobs.Models;

namespace ITJobs.DTO
{
    public class UserProfilesDTO
    {
        public long Id { get; set; }
        public required string FullName { get; set; }
        public string? Avatar { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
        public string? GitHub { get; set; }
        public string? Linkedin { get; set; }
    }
}
