namespace ITJobs.DTO
{
    public class UserDTO
    {
        public long Id { get; set; } = DateTime.UtcNow.Ticks / 100;
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
    }
    

}
