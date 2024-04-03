﻿using AutoMapper;
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
        }
    }
}
