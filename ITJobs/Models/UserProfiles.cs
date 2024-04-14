namespace ITJobs.Models
{
    public class UserProfiles
    {
        public long Id { get; set; }
        public  User? User { get; set; }
        public string FullName { get; set; }
        public string? Avatar { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
        public string? GitHub { get; set; }
        public string? Linkedin { get; set; }
    }

    public class UserProfiles_Create
    {
        public required string FullName { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
    }
}
