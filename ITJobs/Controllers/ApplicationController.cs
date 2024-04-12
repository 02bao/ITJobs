using AutoMapper;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public ApplicationController(IApplicationRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }

        [HttpPost("AddNewApply")]
        public IActionResult AddNewApply(long userid, long jobid, long resumeid)
        {
            bool tmp = _applicationRepository.AddNewApply(userid, jobid, resumeid);
            if(tmp)
            {
                return Ok("Apply Successfully, Please wait Company response");
            }
            return BadRequest("Apply Failed, Please try again!");
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var applications = _mapper.Map<List<ApplicationDTO>>(_applicationRepository.GetAll());
            return Ok(applications);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(long id)
        {
            var applications = _mapper.Map<ApplicationDTO>(_applicationRepository.GetById(id));
            return Ok(applications);
        }

        [HttpGet("GetByUserid")]
        public IActionResult GetByUserid([FromQuery] long userId)
        {
            var applications = _mapper.Map<List<ApplicationDTO>>(_applicationRepository.GetByUserId(userId));
            return Ok(applications);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] ApplicationDTO _DTO)
        {
            var applies = _mapper.Map<Application>(_DTO);
            bool tmp = _applicationRepository.Update(applies);
            if(tmp)
            {
                return Ok("Update successfully");
            }
            return BadRequest("Update Failed, Please try again!");
        }
    }
}
