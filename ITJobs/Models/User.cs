namespace ITJobs.Models
{
    public class User
    {
        public long Id { get; set; } = DateTime.UtcNow.Ticks / 100;
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
        public  List<UserProfiles>? UserProfiles { get; set; }
        public  List<UserPost>? UserPosts { get; set; }
        public  List<Company>? Companies { get; set; }
    }

    public class User_Register
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
    }
    public class User_login
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }

    
    
}
