using AutoMapper;
using ITJobs.DTO;
using ITJobs.Models;

namespace ITJobs.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<User_login, UserDTO>();
            CreateMap<UserDTO, User_login>();
        }
    }
}
