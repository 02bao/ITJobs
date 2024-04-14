namespace ITJobs.Models;

public class Review
{
    public long Id { get; set; }
    public User? Users { get; set; }
    public Company? Companies { get; set; }
    public string Title { get; set; } = string.Empty;
    public required string Comment { get; set; }
    public long Like { get; set; } = 0;
    public long Dislike { get; set; } = 0;
    public int Rating { get; set; } = 0;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
