using AutoMapper;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobSearchController : ControllerBase
    {
        private readonly IJobSearchRepository _jobSearchRepository;
        private readonly IMapper _mapper;

        public JobSearchController(IJobSearchRepository jobSearchRepository , IMapper mapper)
        {
            _jobSearchRepository = jobSearchRepository;
            _mapper = mapper;
        }

        [HttpPost("JobSearch")]
        public IActionResult JobSearch(long userid, JobDesired job)
        {
            var search = _jobSearchRepository.SearchForUser(userid, job);
            return Ok(search);
        }

        [HttpGet("GetAll")]
        public IActionResult GetList()
        {
            var job = _mapper.Map<List<JobSearchDTO>>(_jobSearchRepository.GetAll());
            return Ok(job);
        }
    }
}
