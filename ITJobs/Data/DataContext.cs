using ITJobs.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace ITJobs.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfiles> UserProfiles { get; set; }
        public DbSet<Resume> Resume { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<UserPost> UserPosts { get; set; }
        public DbSet<CompanyPost> CompanyPosts { get; set; }
        public DbSet<JobSearch> JobSearches { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public static string configsql = "Host=localhost:5432;Database=ITJobs;Username=postgres;Password=postgres";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); 
            optionsBuilder.UseNpgsql(configsql);
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
