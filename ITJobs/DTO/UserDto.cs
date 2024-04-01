namespace ITJobs.DTO
{
    public class UserDto
    {
        public long Id { get; set; } = DateTime.UtcNow.Ticks / 100;
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
