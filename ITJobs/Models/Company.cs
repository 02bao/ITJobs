namespace ITJobs.Models
{
    public class Company
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Description { get; set; }
        public required string Location { get; set; }
        public required string Industry { get; set; }
        public required string Website { get; set; }
        public long? size { get; set; }
        public required User User { get; set; }
        public required List<CompanyPost> CompanyPosts { get; set; }
        public required List<Category> Categories { get; set; }
        public required List<Job> Jobs { get; set; }
    }

    public class Company_Create
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Industry { get; set; }
    }
}
