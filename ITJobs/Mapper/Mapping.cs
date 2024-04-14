using AutoMapper;
using ITJobs.DTO;
using ITJobs.Models;

namespace ITJobs.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserDTO, User>();
            CreateMap<UserProfiles, UserProfilesDTO>();
            CreateMap<UserProfilesDTO, UserProfiles>();
            CreateMap<Resume, ResumeDTO>();
            CreateMap<ResumeDTO, Resume>();
            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyDTO, Company>();
            CreateMap<UserPost, UserPostDTO>();
            CreateMap<UserPostDTO, UserPost>();
            CreateMap<CompanyPost, CompanyPostDTO>();
            CreateMap<CompanyPostDTO, CompanyPost>();
            CreateMap<JobSearch, JobSearchDTO>();
            CreateMap<JobSearchDTO, JobSearch>();
            CreateMap<JobDTO, Job>();
            CreateMap<Job, JobDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Application, ApplicationDTO>();
            CreateMap<ApplicationDTO, Application>();
            CreateMap<Notification, NotificationDTO>();
            CreateMap<NotificationDTO, Notification>();
            CreateMap<Review, ReviewDTO>();
            CreateMap<ReviewDTO, Review>();
            CreateMap<ReviewDTO_Create, Review_Create>();
            CreateMap<Review_Create, ReviewDTO_Create>();
        }
    }
}
