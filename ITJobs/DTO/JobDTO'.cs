namespace ITJobs.DTO
{
    public class JobDTO // tên file sao có dấu ' vậy ba
    {
        public long Id { get; set; }
        public string NameJob { get; set; }
        public string Location { get; set; }
        public string Position { get; set; }
        public string Salary { get; set; }
        public string Experience { get; set; }
        public string Field { get; set; }
        public string? Requirements { get; set; }
        public DateTime Deadline { get; set; } = DateTime.UtcNow;
    }
}
