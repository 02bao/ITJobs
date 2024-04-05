﻿using AutoMapper;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CVController : ControllerBase
    {
        private readonly ICVRepository _cVRepository;
        private readonly IMapper _mapper;

        public CVController(ICVRepository cVRepository, IMapper mapper)
        {
            _cVRepository = cVRepository;
            _mapper = mapper;
        }

        [HttpPost("CreateNewCv")]
        public IActionResult CreateNewCv(long userid, [FromBody] CVDTO _DTO)
        {
            var users = _mapper.Map<CV>(_DTO);
            bool tmp = _cVRepository.CreateNewCV(userid, users);
            if(tmp)
            {
                return Ok("Create New CV Successfully");
            }
            return BadRequest("Create Failed, Please try again!");
        }
    }
}
