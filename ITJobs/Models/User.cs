namespace ITJobs.Models
{
    public class User
    {
        public long Id { get; set; } = DateTime.UtcNow.Ticks / 100;
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public List<UserProfiles> UserProfiles { get; set; }
    }
    public class User_login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    
}
