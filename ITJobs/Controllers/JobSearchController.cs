using AutoMapper;
using ITJobs.Interface;
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
    }
}
