using AutoMapper;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobSearchController(
    IJobSearchRepository _jobSearchRepository, 
    IMapper _mapper) : ControllerBase
{
    [HttpPost("JobSearch")]
    public IActionResult JobSearch(long userid, JobDesired job)
    {
        List<CompanyPost> search = _jobSearchRepository.SearchForUser(userid, job);
        return Ok(search);
    }

    [HttpGet("GetAll")]
    public IActionResult GetList()
    {
        List<JobSearchDTO> job = _mapper.Map<List<JobSearchDTO>>(_jobSearchRepository.GetAll());
        return Ok(job);
    }

    [HttpGet("GetById")]
    public IActionResult GetById(long id)
    {
        var job = _mapper.Map<JobSearchDTO>(_jobSearchRepository.GetById(id));
        return Ok(job);
    }
}
