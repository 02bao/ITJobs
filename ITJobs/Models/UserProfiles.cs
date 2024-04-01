namespace ITJobs.Models
{
    public class UserProfiles
    {
        public long Id { get; set; }
        public User user { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
