namespace ITJobs.Models
{
    public class UserProfiles
    {
        public long Id { get; set; }
        public User User { get; set; }
        public string FullName { get; set; }
        public string? Avatar { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string? GitHub { get; set; }
        public string? Linkedin { get; set; }
    }
}
