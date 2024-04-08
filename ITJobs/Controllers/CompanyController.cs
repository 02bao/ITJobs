﻿using AutoMapper;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyRepository companyRepository , IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        [HttpPost("CreateNewCompany")]
        public IActionResult CreateNewCompany([FromBody] CompanyDTO _DTO, long userid)
        {
            var company = _mapper.Map<Company>(_DTO);
            bool tmp = _companyRepository.CreateNewCompany(company, userid);
            if(tmp)
            {
                return Ok("Create New Company Successfully");
            }
            return BadRequest("Create Failed, Please try again!");
        }
    }
}
