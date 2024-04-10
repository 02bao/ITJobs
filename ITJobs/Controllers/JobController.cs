using AutoMapper;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

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
        public IActionResult CreateNewJob(long companyid, Job_Create jobs, long categoryid, DateTime NewDate)
        {
            bool tmp = _jobRepository.CreateNewJob(companyid, jobs, categoryid, NewDate);
            if (tmp)
            {
                return Ok("Create New Job Successfully");
            }
            return BadRequest("Create Failed, Please try again!");
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var jobs = _mapper.Map<List<JobDTO>>(_jobRepository.GetAll());
            return Ok(jobs);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(long id)
        {
            var jobs = _mapper.Map<JobDTO>(_jobRepository.GetById(id));
            return Ok(jobs);
        }

        [HttpGet("GetByCompanyId")]
        public IActionResult GetByCompanyId(long companyid)
        {
            var jobs = _mapper.Map<List<JobDTO>>(_jobRepository.GetByCompanyId(companyid));
            return Ok(jobs);
        }

        [HttpGet("GetByCategoryid")]
        public IActionResult GetByCategoryid(long categoryid)
        {
            var jobs = _mapper.Map<List<JobDTO>>(_jobRepository.GetByCategoryid(categoryid));
            return Ok(jobs);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] JobDTO _DTO)
        {
            var job = _mapper.Map<Job>(_DTO);
            bool tmp = _jobRepository.Update(job);
            if (tmp)
            {
                return Ok("Update Successfully");
            }
            return BadRequest("Update Failed, Please try again!");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(long id)
        {
            bool tmp = _jobRepository.Delete(id);
            if (tmp)
            {
                return Ok("Delete Succesfully");
            }
            return BadRequest("Delete Failed, Please try again!");
        }
    }
}
