using AutoMapper;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;

        public JobController(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        [HttpPost("CreateNewJob")]
        public IActionResult CreateNewJob(long companyid , Job_Create jobs, DateTime NewDate)
        {
            bool tmp = _jobRepository.CreateNewJob(companyid, jobs, NewDate);
            if(tmp)
            {
                return Ok("Create New Job Successfully");
            }
            return BadRequest("Create Failed, Please try again!");
        }
    }
}
