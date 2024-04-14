using ITJobs.Models;

namespace ITJobs.DTO;

public class ReviewDTO
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public required string Comment { get; set; }
    public long Like { get; set; } = 0;
    public long Dislike { get; set; } = 0;
    public int Rating { get; set; } = 0;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}

public class ReviewDTO_Create
{
    public string Title { get; set; } = string.Empty;
    public required string Comment { get; set; }
    public int Rating { get; set; } = 0;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
