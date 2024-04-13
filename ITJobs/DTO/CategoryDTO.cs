namespace ITJobs.DTO
{
    public class CategoryDTO
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;// gán giá trị ban đầu
        public string? Description { get; set; }
    }
    // null là không giá trị
}
