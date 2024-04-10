namespace ITJobs.Models
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Company Companies { get; set; }
        public List<Job>? Jobs { get; set; }
    }
    public class Category_Create
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
