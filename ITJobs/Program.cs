
using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Repository;

namespace ITJobs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddDbContext<DataContext>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserProfilesRepository, UserProfilesRepository>();
            builder.Services.AddScoped<IResumeRepository, ResumeRepository>();
            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
            builder.Services.AddScoped<IUserPostRepository, UserPostRepository>();
            builder.Services.AddScoped<ICompanyPostRepository, CompanyPostRepository>();
            builder.Services.AddScoped<IJobSearchRepository, JobSearchRepository>();
            builder.Services.AddScoped<IJobRepository, JobRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
            builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
            builder.Services.AddScoped<IConverSationRepository, ConverSationRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
