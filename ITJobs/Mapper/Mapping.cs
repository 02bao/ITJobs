using AutoMapper;
using ITJobs.DTO;
using ITJobs.Models;

namespace ITJobs.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User , UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<UserProfiles, UserProfilesDTO>();
            CreateMap<UserProfilesDTO, UserProfiles>();
            CreateMap<Resume, ResumeDTO>();
            CreateMap<ResumeDTO, Resume>();
            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyDTO, Company>();
        }
    }
}
