namespace ITJobs.DTO
{
    public class CompanyDTO
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Description { get; set; }
        public required string Location { get; set; }
        public required string Industry { get; set; }
        public required string Website { get; set; }
        public long size { get; set; }
    }
}
