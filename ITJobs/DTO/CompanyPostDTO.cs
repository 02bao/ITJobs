namespace ITJobs.DTO
{
    public class CompanyPostDTO
    {
        public long Id { get; set; }
        public required string NamePost { get; set; }
        public required string Location { get; set; }
        public required string Position { get; set; }
        public required string Content { get; set; }
        public string? Image { get; set; } // ở đây để dấu chấm hỏi nó sẽ không warning null cho anh, nhưng mà anh nên tránh dùng nó nếu không cần thiết
        public int? Like { get; set; }
        public int Parent { get; set; }
        public List<string>? Comment { get; set; }
        public DateTime? Timestamp { get; set; } = DateTime.UtcNow;
        public DateTime? ExpirationDate { get; set; } = DateTime.UtcNow;
        public required string Salary { get; set; }
        public int? ApplicationCount { get; set; }
        public required string WorkingMode { get; set; }
        public required string Experience { get; set; }
        public required string Field { get; set; }
    }
}
